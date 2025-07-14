namespace EasyMultiVideoCompare
{
    public partial class UCVideoViewer : UserControl
    {
        #region --- Variables ---

        CVideoFile MainFile;
        CVideoFile CompareFile;

        Bitmap MainBitmap;
        Bitmap CompareBitmap;
        Bitmap CompareBitmapResized;
        int MousePos;
        bool MoveSliderProgramatically = false;

        #endregion

        #region --- Constructor + Save/Load FromConfig ---

        public UCVideoViewer()
        {
            InitializeComponent();
            EnableControl(false);
        }

        public void LoadFromConfig()
        {
            cb_OneCompare.Checked = CConfig.VideoViewer_OneImage;
            cb_MakeImagesSameSize.Checked = CConfig.VideoViewer_SameSize;
            cb_MoveSlidersTogether.Checked = CConfig.VideoViewer_MoveTogether;
        }

        public void SaveToConfig()
        {
            CConfig.VideoViewer_OneImage = cb_OneCompare.Checked;
            CConfig.VideoViewer_SameSize = cb_MakeImagesSameSize.Checked;
            CConfig.VideoViewer_MoveTogether = cb_MoveSlidersTogether.Checked;
        }

        #endregion

        #region --- EnableControl ---

        void EnableControl(bool bEnable = true)
        {
            tb_MainVid.Enabled = bEnable;
            tb_CompareVid.Enabled = bEnable;
            cb_MoveSlidersTogether.Enabled = bEnable;
            cb_OneCompare.Enabled = bEnable;
            cb_MakeImagesSameSize.Enabled = bEnable;
            gb_CompareVid.Enabled = bEnable;
            gb_MainVid.Enabled = bEnable;
        }

        #endregion

        #region --- Set/Clear Videos ---

        public void SetVideos(CVideoFile mainFile, CVideoFile compareFile)
        {
            MainFile = mainFile;
            CompareFile = compareFile;

            gb_MainVid.Text = MainFile.GeneralInfo.Name;
            gb_CompareVid.Text = CompareFile.GeneralInfo.Name;

            tb_MainVid.Maximum = Convert.ToInt32(MainFile.VideoInformation.FrameCount - 1);
            tb_CompareVid.Maximum = Convert.ToInt32(CompareFile.VideoInformation.FrameCount - 1);
            tb_MainVid.Value = 0;
            tb_CompareVid.Value = 0;

            MousePos = pb_Video.Width / 2;

            EnableControl();

            UpdateMainBitmap();
            UpdateCompareBitmap();
            UpdateImage();
        }

        public void ClearVideos()
        {
            MainFile = null;
            CompareFile = null;

            gb_MainVid.Text = "";
            gb_CompareVid.Text = "";

            EnableControl(false);

            pb_Video.Image = null;
        }

        #endregion

        #region --- Scroll Videos ---

        private void tb_MainVid_Scroll(object sender, EventArgs e)
        {
            if (cb_MoveSlidersTogether.Checked && !MoveSliderProgramatically)
            {
                MoveSliderProgramatically = true;
                tb_CompareVid.Value = Math.Clamp(tb_CompareVid.Minimum, tb_MainVid.Value, tb_CompareVid.Maximum);
                UpdateCompareBitmap();
                MoveSliderProgramatically = false;
            }
            UpdateMainBitmap();
            UpdateImage();
        }

        private void tb_CompareVid_Scroll(object sender, EventArgs e)
        {
            if (cb_MoveSlidersTogether.Checked && !MoveSliderProgramatically)
            {
                MoveSliderProgramatically = true;
                tb_MainVid.Value = Math.Clamp(tb_MainVid.Minimum, tb_CompareVid.Value, tb_MainVid.Maximum);
                UpdateMainBitmap();
                MoveSliderProgramatically = false;
            }
            UpdateCompareBitmap();
            UpdateImage();
        }

        #endregion

        #region --- Read new Frames from video

        void UpdateMainBitmap()
        {
            gb_MainVid.Text = $"Frame {tb_MainVid.Value+1} of {MainFile.VideoInformation.FrameCount}";
            (MainBitmap, string? message) = VideoFrameReaderOpenCvSharp.ReadFrame(MainFile.GeneralInfo.FullName, tb_MainVid.Value);
            if (MainBitmap == null)
                MainBitmap = Resources.error;
        }

        void UpdateCompareBitmap()
        {
            gb_CompareVid.Text = $"Frame {tb_CompareVid.Value+1} of {CompareFile.VideoInformation.FrameCount}";
            (CompareBitmap, string? message) = VideoFrameReaderOpenCvSharp.ReadFrame(CompareFile.GeneralInfo.FullName, tb_CompareVid.Value);

            if (CompareBitmap == null)
                CompareBitmap = Resources.error;

            int maxheight = Math.Max(MainBitmap.Height, CompareBitmap.Height);
            int maxwidth = Math.Max(MainBitmap.Width, CompareBitmap.Width);
            CompareBitmapResized = new Bitmap(CompareBitmap, maxwidth, maxheight);
        }

        #endregion

        #region --- Update video preview(s) ---

        void UpdateImage()
        {
            if (MainBitmap == null || CompareBitmap == null)
            {
                pb_Video.Image = Resources.error;
                return;
            }

            int maxheight = Math.Max(MainBitmap.Height, CompareBitmap.Height);
            int maxwidth = Math.Max(MainBitmap.Width, CompareBitmap.Width);
            Bitmap bmp;

            if (cb_OneCompare.Checked) //At the same position (Mouse position decides which to show)
            {
                bmp = new Bitmap(maxwidth, maxheight);
                Graphics g = Graphics.FromImage(bmp);
                g.Clear(Color.Black);

                Size calc = new Size(maxwidth, maxheight);
                Size calc2 = calc.ResizeKeepAspect(pb_Video.Width, pb_Video.Height, true);
                int iStartPos = Convert.ToInt32(pb_Video.Width / 2.0 - calc2.Width / 2.0);
                int iEndPos = Convert.ToInt32(pb_Video.Width / 2.0 + calc2.Width / 2.0);
                int iRealPos = 0;
                if (MousePos < iStartPos)
                    iRealPos = 0;
                else if (MousePos > iEndPos)
                    iRealPos = pb_Video.Width;
                else
                    iRealPos = MousePos;
                iRealPos = Convert.ToInt32((iRealPos - iStartPos) * ((double)calc.Height / calc2.Height));


                if (cb_MakeImagesSameSize.Checked)
                {
                    g.DrawImage(MainBitmap, 0, 0, maxwidth, maxheight);
                    g.DrawImage(CompareBitmapResized, iRealPos, 0, new Rectangle(iRealPos, 0, maxwidth - iRealPos, maxheight), GraphicsUnit.Pixel);
                }
                else
                {
                    g.DrawImage(MainBitmap, 0, 0, MainBitmap.Width, MainBitmap.Height);
                    g.DrawImage(CompareBitmap, iRealPos, 0, new Rectangle(iRealPos, 0, CompareBitmap.Width - iRealPos, CompareBitmap.Height),
                        GraphicsUnit.Pixel);
                }
                g.DrawLine(new Pen(Color.White), new Point(iRealPos, 0), new Point(iRealPos, bmp.Height));
            }
            else //Next to each other
            {
                bmp = new Bitmap(maxwidth * 2 + 1, maxheight);
                Graphics g = Graphics.FromImage(bmp);
                g.Clear(Color.Black);

                Size szMain = MainBitmap.Size.ResizeKeepAspect(maxwidth, maxheight);
                Size szCompare = CompareBitmap.Size.ResizeKeepAspect(maxwidth, maxheight);

                if (cb_MakeImagesSameSize.Checked)
                {
                    g.DrawImage(MainBitmap, 0, 0, maxwidth, maxheight);
                    g.DrawImage(CompareBitmap, maxwidth + 1, 0, maxwidth, maxheight);
                }
                else
                {
                    g.DrawImage(MainBitmap, 0, 0, szMain.Width, szMain.Height);
                    g.DrawImage(CompareBitmap, maxwidth + 1, 0, szCompare.Width, szCompare.Height);
                }
            }

            pb_Video.Image = bmp;
        }

        #endregion

        #region --- Update Events ---

        private void cb_OneCompare_CheckedChanged(object sender, EventArgs e)
        {
            UpdateImage();
        }

        private void pb_Video_MouseMove(object sender, MouseEventArgs e)
        {
            MousePos = e.X;
            UpdateImage();
        }

        private void pb_Video_MouseLeave(object sender, EventArgs e)
        {
            MousePos = pb_Video.Width / 2;
            UpdateImage();
        }

        private void cb_MakeImagesSameSize_CheckedChanged(object sender, EventArgs e)
        {
            UpdateImage();
        }

        #endregion
    }
}
