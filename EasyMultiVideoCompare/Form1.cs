#region Using...

using DarkModeForms;

#endregion

namespace EasyMultiVideoCompare
{
    public partial class Form1 : Form
    {
        #region --- Variables ---

        List<CVideoFile> m_lstFiles = new List<CVideoFile>();

        List<CResult> m_lstDuplicates = new List<CResult>();

        #endregion

        #region --- Constructor + FormClosing ---

        public Form1()
        {
            InitializeComponent();
            new DarkModeCS(this);
            CConfig.Load();
            ucVideoViewer1.LoadFromConfig();
            //Load Window for position and size before showing
            CConfig.LoadWindow(this, [splitContainer1]);
            lb_Folders.DataSource = CConfig.CompareFolders;
            Text = Text + " - v" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            //Load window again to set the splitter distance
            CConfig.LoadWindow(this, [splitContainer1]);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ucVideoViewer1.SaveToConfig();
            CConfig.Save();
            CConfig.SaveWindow(this, [splitContainer1]);
        }

        #endregion

        #region --- Button Events ---

        private void btn_AddFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Choose a comparision folder...";
            dialog.Multiselect = true;
            dialog.UseDescriptionForTitle = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string s in dialog.SelectedPaths)
                    if (!CConfig.CompareFolders.Contains(s))
                        CConfig.CompareFolders.Add(s);
                lb_Folders.Invalidate();
            }
        }

        private void btn_RemoveSelectedFolder_Click(object sender, EventArgs e)
        {
            if (lb_Folders.SelectedItems.Count == 0)
                return;

            CConfig.CompareFolders.RemoveAt(lb_Folders.SelectedIndex);
            lb_Folders.Invalidate();
        }

        private void btn_Options_Click(object sender, EventArgs e)
        {
            if (new FormSettings().ShowDialog(this) == DialogResult.OK)
                CConfig.Save();
        }

        private void btn_Run_Click(object sender, EventArgs e)
        {
            CConfig.Save();
            btn_AddFolder.Enabled = false;
            btn_RemoveSelectedFolder.Enabled = false;
            btn_Options.Enabled = false;
            btn_Run.Enabled = false;

            tc_Main.SelectTab(1);
            RunCompare();
        }

        #endregion

        #region --- Run Comparision ---

        void RunCompare()
        {
            new Task(() =>
            {
                //search video files
                m_lstFiles.Clear();
                m_lstDuplicates.Clear();

                SearchOption so = SearchOption.TopDirectoryOnly;
                if (CConfig.SearchRecursive)
                    so = SearchOption.AllDirectories;

                bool bFileSearchComplete = false;
                new Task(() =>
                {
                    foreach (string strPath in CConfig.CompareFolders)
                        foreach (FileInfo fi in new DirectoryInfo(strPath).GetFiles("*", so))
                            if (fi.Extension.Length > 1 && CConfig.SearchFileTypes.Contains(fi.Extension.Substring(1)))
                                m_lstFiles.Add(new CVideoFile(fi));
                    bFileSearchComplete = true;
                }).Start();

                while (!bFileSearchComplete)
                {
                    Thread.Sleep(250);
                    Invoke((MethodInvoker)delegate
                    {
                        tb_Log.Text = "[" + DateTime.Now.ToString("HH:mm:ss.fff") + "] " + $"Loaded {m_lstFiles.Count} videos until now...\r\n";
                    });
                }
                Invoke((MethodInvoker)delegate
                {
                    tb_Log.Text = "[" + DateTime.Now.ToString("HH:mm:ss.fff") + "] " + $"Loaded {m_lstFiles.Count} videos!\r\n";
                    lpb_RunProgressCreateHashes.Maximum = m_lstFiles.Count;
                    lpb_RunProgressCompare.Maximum = m_lstFiles.Count;
                    lpb_RunProgressOverall.Maximum = m_lstFiles.Count * 2;
                });

                // Generate compare hashes
                for (int i = 0; i < m_lstFiles.Count; i++)
                {
                    UpdateState(i, -1, $"Loading compare hash [{(i + 1)}/{m_lstFiles.Count}] {m_lstFiles[i].GeneralInfo.Name}...");
                    m_lstFiles[i].GenerateCompareHashes();
                }

                //compare
                for (int i = 0; i < m_lstFiles.Count; i++)
                {
                    UpdateState(m_lstFiles.Count, i, $"Comparing [{(i + 1)}/{m_lstFiles.Count}] {m_lstFiles[i].GeneralInfo.Name}...");

                    DoCompareFile(m_lstFiles[i]);
                }

                //output results
                UpdateState(m_lstFiles.Count, m_lstFiles.Count, "Putting out results...");
                OutputResults();
                Invoke((MethodInvoker)delegate
                {
                    lpb_RunProgressCreateHashes.Value = lpb_RunProgressCreateHashes.Maximum;
                    lpb_RunProgressCompare.Value = lpb_RunProgressCompare.Maximum;
                    lpb_RunProgressOverall.Value = lpb_RunProgressOverall.Maximum;
                    tc_Main.SelectTab(2);

                    btn_AddFolder.Enabled = true;
                    btn_RemoveSelectedFolder.Enabled = true;
                    btn_Options.Enabled = true;
                    btn_Run.Enabled = true;
                });

            }).Start();
        }

        void DoCompareFile(CVideoFile pFile_)
        {
            CResult result = new CResult(pFile_);
            for (int i = 0; i < m_lstFiles.Count; i++)
            {
                //Do not compare already compared files again
                if (IsAlreadyCompared(pFile_, m_lstFiles[i]))
                    continue;

                //TODO Compress matches to one per overlapping.
                //TODO Matches where middle of video is cut is NOT showing!

                List<CHashMatch> matches = VideoHasher.FindClipInVideo(
                        pFile_.CompareHashes, m_lstFiles[i].CompareHashes, CConfig.MaxHammingDistance, CConfig.MinMatchRatio);

                if (matches.Count > 0)
                {
                    double dist = 0;
                    foreach (var match in matches)
                    {
                        dist += match.HammingDistance;
                    }
                    if (!m_lstDuplicates.Contains2(m_lstFiles[i]))
                        result.AddCompareFile(m_lstFiles[i], dist / matches.Count, matches);
                }
            }

            if (result.ComparableFiles.Count > 0)
                m_lstDuplicates.Add(result);
        }

        bool IsAlreadyCompared(CVideoFile pFile1_, CVideoFile pFile2_)
        {
            //Same File
            if (pFile1_.GeneralInfo.FullName == pFile2_.GeneralInfo.FullName)
                return true;

            foreach (var match in m_lstDuplicates)
            {
                //One of the main files
                if (match.File.GeneralInfo.FullName == pFile1_.GeneralInfo.FullName)
                {
                    foreach (var match2 in match.ComparableFiles)
                        if (match2.File.GeneralInfo.FullName == pFile2_.GeneralInfo.FullName)
                            return true;
                }
                if (match.File.GeneralInfo.FullName == pFile2_.GeneralInfo.FullName)
                {
                    foreach (var match2 in match.ComparableFiles)
                        if (match2.File.GeneralInfo.FullName == pFile1_.GeneralInfo.FullName)
                            return true;
                }

                //one of the compared files
                foreach (var match2 in match.ComparableFiles)
                {
                    if (match2.File.GeneralInfo.FullName == pFile2_.GeneralInfo.FullName)
                    {
                        if (pFile1_.GeneralInfo.FullName == match.File.GeneralInfo.FullName)
                            return true;

                        foreach (var match3 in match.ComparableFiles)
                            if (match3.File.GeneralInfo.FullName == pFile1_.GeneralInfo.FullName)
                                return true;
                    }
                    if (match2.File.GeneralInfo.FullName == pFile1_.GeneralInfo.FullName)
                    {
                        if (pFile2_.GeneralInfo.FullName == match.File.GeneralInfo.FullName)
                            return true;

                        foreach (var match3 in match.ComparableFiles)
                            if (match3.File.GeneralInfo.FullName == pFile2_.GeneralInfo.FullName)
                                return true;
                    }
                }
            }

            return false;
        }

        //TODO Add Delete Video button (also automatic)
        //TODO timeline for matches
        void OutputResults()
        {
            Invoke((MethodInvoker)delegate
            {
                flp_Results.Controls.Clear();
            });
            m_lstDuplicates = m_lstDuplicates.OrderBy(b => b.HammingDistance).ToList();

            foreach (CResult res in m_lstDuplicates)
            {
                //TODO Show one item PER match instead per video in view...
                UCResult uc = new UCResult();
                uc.Padding = new Padding(0);
                uc.Margin = new Padding(0, 0, 0, 4);
                uc.Width = flp_Results.Width - 20;
                uc.SetResult(res);
                uc.SelectCompare += Uc_SelectCompare;
                Invoke((MethodInvoker)delegate
                {
                    flp_Results.Controls.Add(uc);
                });
            }
        }

        private void Uc_SelectCompare(object sender, EventArgs e)
        {
            Tuple<CResult, CResultCompare> Res_Comp = (Tuple < CResult, CResultCompare > )sender;
            foreach (UCResult res in flp_Results.Controls)
            {
                if (res.Result != Res_Comp.Item1)
                    res.Deselect();
            }

            SetResultViewer(Res_Comp.Item1, Res_Comp.Item2);
        }

        #endregion

        #region --- UpdateState ---

        void UpdateState(int iProgressCreateHashes_, int iProgressCompare_, string strText = "")
        {
            Invoke((MethodInvoker)delegate
            {
                if (!string.IsNullOrWhiteSpace(strText))
                    tb_Log.AppendText("[" + DateTime.Now.ToString("HH:mm:ss.fff") + "] " + strText + "\r\n");
                if (iProgressCreateHashes_ != -1)
                    lpb_RunProgressCreateHashes.Value = iProgressCreateHashes_;
                if (iProgressCompare_ != -1)
                    lpb_RunProgressCompare.Value = iProgressCompare_;
                lpb_RunProgressOverall.Value = lpb_RunProgressCreateHashes.Value + lpb_RunProgressCompare.Value;
            });
        }

        #endregion

        #region --- Select files to compare ---

        private void SetResultViewer(CResult res, CResultCompare comp)
        {
            CResultCompare selResultCompare = comp;
            CResult selResult = res;

            tv_ResultFile1.Nodes.Clear();
            TreeNode tnMain1 = tv_ResultFile1.Nodes.Add(selResult.File.GeneralInfo.Name);


            tv_ResultFile2.Nodes.Clear();
            TreeNode tnMain2 = tv_ResultFile2.Nodes.Add(selResultCompare.File.GeneralInfo.Name);

            bool bSame = true;
            if (!CreateCompareTreeNode(tnMain1, tnMain2, "File size", GetSizeHumanReadAble(selResult.File.GeneralInfo.Length),
                GetSizeHumanReadAble(selResultCompare.File.GeneralInfo.Length)))
                bSame = false;
            if (!CreateCompareTreeNode(tnMain1, tnMain2, "Extension", selResult.File.GeneralInfo.Extension,
                selResultCompare.File.GeneralInfo.Extension))
                bSame = false;

            if (!CreateCompareTreeNode(tnMain1, tnMain2, "Duration", FormatSecondsToHmsFff(selResult.File.VideoInformation.Duration),
                FormatSecondsToHmsFff(selResultCompare.File.VideoInformation.Duration)))
                bSame = false;
            if (!CreateCompareTreeNode(tnMain1, tnMain2, "Bitrate", GetSizeHumanReadAble(selResult.File.VideoInformation.Bitrate) + "it/s",
                GetSizeHumanReadAble(selResultCompare.File.VideoInformation.Bitrate) + "it/s"))
                bSame = false;
            if (!CreateCompareTreeNode(tnMain1, tnMain2, "Resolution", selResult.File.VideoInformation.Resolution,
                selResultCompare.File.VideoInformation.Resolution))
                bSame = false;
            if (!CreateCompareTreeNode(tnMain1, tnMain2, "FPS", selResult.File.VideoInformation.FPS.ToString(),
                selResultCompare.File.VideoInformation.FPS.ToString()))
                bSame = false;

            tnMain1.BackColor = bSame ? Color.FromArgb(0, 96, 0) : Color.FromArgb(128, 0, 0);
            tnMain2.BackColor = bSame ? Color.FromArgb(0, 96, 0) : Color.FromArgb(128, 0, 0);

            ucVideoViewer1.SetVideos(selResult.File, selResultCompare);

            tnMain1.ExpandAll();
            tnMain2.ExpandAll();
        }

        private bool CreateCompareTreeNode(TreeNode tnMain1, TreeNode tnMain2, string label, string str1, string str2)
        {
            TreeNode tn1 = tnMain1.Nodes.Add(label + ": " + str1);
            TreeNode tn2 = tnMain2.Nodes.Add(label + ": " + str2);
            tn1.BackColor = (str1 == str2) ? Color.FromArgb(0, 96, 0) : Color.FromArgb(128, 0, 0);
            tn2.BackColor = (str1 == str2) ? Color.FromArgb(0, 96, 0) : Color.FromArgb(128, 0, 0);
            return (str1 == str2);
        }

        #endregion

        #region --- Formatting functions ---

        public static string FormatSecondsToHmsFff(double totalSeconds)
        {
            TimeSpan duration = TimeSpan.FromSeconds(totalSeconds);

            long totalHours = (long)duration.TotalHours;
            int minutes = duration.Minutes;
            int seconds = duration.Seconds;
            int milliseconds = duration.Milliseconds;

            return $"{totalHours:D2}:{minutes:D2}:{seconds:D2}.{milliseconds:D3}";
        }
        public static string GetSizeHumanReadAble(long lSize_, string format = "0.##")
        {
            string strType = " B";
            double dblReturn = Convert.ToDouble(lSize_);

            if (dblReturn / 1024.0 > 1)
            {
                dblReturn = dblReturn / 1024.0;
                strType = " KB";
                if (dblReturn / 1024.0 > 1)
                {
                    dblReturn = dblReturn / 1024.0;
                    strType = " MB";
                    if (dblReturn / 1024.0 > 1)
                    {
                        dblReturn = dblReturn / 1024.0;
                        strType = " GB";
                        if (dblReturn / 1024.0 > 1)
                        {
                            dblReturn = dblReturn / 1024.0;
                            strType = " TB";
                        }
                    }
                }
            }
            return dblReturn.ToString(format) + strType;
        }

        #endregion

        private void flp_Results_Resize(object sender, EventArgs e)
        {
            Timer_Resize.Stop();
            Timer_Resize.Start();
        }
        private void Timer_Resize_Tick(object sender, EventArgs e)
        {
            foreach (Control c in flp_Results.Controls)
            {
                c.Width = flp_Results.Width - 20;
            }

        }
    }
}
