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

                    DoCompareFile(m_lstFiles[i], i);
                }

                //output results
                OutputResults();
                Invoke((MethodInvoker)delegate
                {
                    lpb_RunProgressCreateHashes.Value = lpb_RunProgressCreateHashes.Maximum;
                    tc_Main.SelectTab(2);

                    btn_AddFolder.Enabled = true;
                    btn_RemoveSelectedFolder.Enabled = true;
                    btn_Options.Enabled = true;
                    btn_Run.Enabled = true;
                });

            }).Start();
        }

        void DoCompareFile(CVideoFile pFile_, int iCurPos_)
        {
            CResult result = new CResult(pFile_);
            for (int i = iCurPos_ + 1; i < m_lstFiles.Count; i++)
            {
                List<(int startIndex, double avgHammingDistance)> matches = VideoHasher.FindClipInVideo(
                        pFile_.CompareHashes, m_lstFiles[i].CompareHashes, maxHammingDistanceThreshold: CConfig.MaxHammingDistance,
                        minMatchRatio: CConfig.MinMatchRatio);

                if (matches.Count > 0) //TODO Save matches for results view to show where the match was?
                {
                    double dist = 0;
                    foreach (var match in matches)
                    {
                        dist += match.avgHammingDistance;
                    }
                    if (!m_lstDuplicates.Contains2(m_lstFiles[i]))
                        result.AddCompareFile(m_lstFiles[i], dist / matches.Count);
                }
            }

            if (result.ComparableFiles.Count > 0)
                m_lstDuplicates.Add(result);
        }

        void OutputResults()
        {
            Invoke((MethodInvoker)delegate
            {
                itv_Results.ItemHeight = CConfig.PreviewBitmapSize - 12;
            });

            new Task(() =>
            {
                UpdateResultsState("sorting...");
                m_lstDuplicates = m_lstDuplicates.OrderBy(b => b.HammingDistance).ToList();

                int iMain = 1, iComp = 1;
                foreach (CResult fil in m_lstDuplicates)
                {
                    UpdateResultsState($"loading {iMain}/{m_lstDuplicates.Count}...");
                    fil.File.LoadThumbnails(CConfig.PreviewBitmapSize);
                    iComp = 1;
                    foreach (CResultCompare fil2 in fil.ComparableFiles)
                    {
                        UpdateResultsState($"loading {iMain}/{m_lstDuplicates.Count} - compare file {iComp}/{fil.ComparableFiles.Count}...");
                        fil2.File.LoadThumbnails(CConfig.PreviewBitmapSize);
                        iComp++;
                    }
                    iMain++;

                    Invoke((MethodInvoker)delegate
                    {
                        TreeNode tnMain = new TreeNode(fil.File.GeneralInfo.Name);
                        tnMain.Tag = fil;
                        itv_Results.Nodes.Add(tnMain);

                        foreach (CResultCompare fil2 in fil.ComparableFiles)
                        {
                            TreeNode tnComp = new TreeNode(fil2.File.GeneralInfo.Name);
                            tnComp.Tag = fil2;
                            tnMain.Nodes.Add(tnComp);
                        }
                    });
                }
                UpdateResultsState("idle");
            }).Start();
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

        void UpdateResultsState(string strText)
        {
            Invoke((MethodInvoker)delegate
            {
                tssl_ResultsState.Text = "Results state: " + strText;
            });
        }


        #endregion

        #region --- Select files to compare ---

        private void itv_Results_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag.GetType() != typeof(CResultCompare))
            {
                tv_ResultFile1.Nodes.Clear();
                tv_ResultFile2.Nodes.Clear();
                ucVideoViewer1.ClearVideos();
                e.Node.Expand();
                itv_Results.SelectedNode = e.Node.FirstNode;
                return;
            }

            CResultCompare selResultCompare = e.Node.Tag as CResultCompare;
            CResult selResult = e.Node.Parent.Tag as CResult;

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

            tnMain1.BackColor = bSame ? Color.FromArgb(160, 255, 160) : Color.FromArgb(255, 160, 160);
            tnMain2.BackColor = bSame ? Color.FromArgb(160, 255, 160) : Color.FromArgb(255, 160, 160);

            ucVideoViewer1.SetVideos(selResult.File, selResultCompare.File);

            tnMain1.ExpandAll();
            tnMain2.ExpandAll();
        }

        private bool CreateCompareTreeNode(TreeNode tnMain1, TreeNode tnMain2, string label, string str1, string str2)
        {
            TreeNode tn1 = tnMain1.Nodes.Add(label + ": " + str1);
            TreeNode tn2 = tnMain2.Nodes.Add(label + ": " + str2);
            tn1.BackColor = (str1 == str2) ? Color.FromArgb(160, 255, 160) : Color.FromArgb(255, 160, 160);
            tn2.BackColor = (str1 == str2) ? Color.FromArgb(160, 255, 160) : Color.FromArgb(255, 160, 160);
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
    }
}
