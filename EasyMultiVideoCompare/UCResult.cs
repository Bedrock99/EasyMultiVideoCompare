using DarkModeForms;

namespace EasyMultiVideoCompare
{
    public partial class UCResult : UserControl
    {
        public CResult Result = null;
        public event EventHandler SelectCompare;
        public UCResult()
        {
            InitializeComponent();
        }

        private void UCResult_Load(object sender, EventArgs e)
        {
            BackColor = Color.Gray;
            pb_Main.Size = new Size(pb_Main.Width, CConfig.PreviewBitmapSize + 2);
            flp_Compares.Location = new Point(flp_Compares.Location.X, pb_Main.Location.Y * 2 + pb_Main.Height);
            Size = new Size(Width, pb_Main.Location.Y * 2 + pb_Main.Height);
            btn_Expand.Location = new Point(btn_Expand.Location.X, pb_Main.Location.Y + pb_Main.Height / 2 - btn_Expand.Height / 2);
        }

        private void btn_Expand_Click(object sender, EventArgs e)
        {
            if (btn_Expand.Text == "+")
            {
                btn_Expand.Text = "-";
                Size = new Size(Width, flp_Compares.Location.Y + flp_Compares.Height + pb_Main.Location.Y);
            }
            else
            {
                btn_Expand.Text = "+";
                Size = new Size(Width, pb_Main.Location.Y * 2 + pb_Main.Height);
            }
        }
        public void SetResult(CResult res)
        {
            Result = res;
            new Task(() =>
            {
                res.File.LoadThumbnails(CConfig.PreviewBitmapSize);

                int height = 0;
                foreach (CResultCompare comp in res.ComparableFiles)
                {
                    comp.File.LoadThumbnails(CConfig.PreviewBitmapSize);
                    int iWidth = Screen.PrimaryScreen.Bounds.Width;

                    PictureBox pb = new PictureBox();
                    pb.Click += Pb_Click;
                    pb.Padding = new Padding(0);
                    pb.Margin = new Padding(0, 0, 0, 4);
                    pb.Size = new Size(iWidth, CConfig.PreviewBitmapSize + 2);
                    pb.Image = CombineImagesHorizontally(comp.File.Bitmaps, 
                        new List<string> { comp.File.GeneralInfo.Name, "Average Hamming Distance: " + comp.HammingDistance.ToString(), 
                            "Matches: " + comp.Matches.Count.ToString(),
                        $"{comp.Matches[0].StartHashNumber} to {comp.Matches[0].HashCount} as {comp.Matches[0].HammingDistance}"});
                    Invoke((MethodInvoker)delegate
                    {
                        flp_Compares.Controls.Add(pb);
                    });
                    height += CConfig.PreviewBitmapSize + 6;
                }

                Invoke((MethodInvoker)delegate
                {
                    flp_Compares.Size = new Size(flp_Compares.Width, height - 4);
                    btn_Expand.Enabled = true;
                    pb_Main.Image = CombineImagesHorizontally(res.File.Bitmaps,
                        new List<string> { res.File.GeneralInfo.Name, res.ComparableFiles.Count.ToString() + " similar videos" });
                    pb_Main.SizeMode = PictureBoxSizeMode.Normal;
                });

            }).Start();
        }
        public Bitmap CombineImagesHorizontally(List<Bitmap> images, List<string> lines)
        {
            if (images == null || images.Count == 0)
                return null;

            float flongestLine = 0f;
            float highestHeigt = 0f;
            using (Graphics g = Graphics.FromImage(new Bitmap(1, 1)))
            {
                foreach (string line in lines)
                {
                    SizeF sz = g.MeasureString(line, Font);
                    if (sz.Width > flongestLine)
                        flongestLine = sz.Width;
                    if (sz.Height > highestHeigt)
                        highestHeigt = sz.Height;
                }
            }
            int longestLine = Convert.ToInt32(Math.Ceiling(flongestLine));
            int totalWidth = images.Sum(img => img.Width) + longestLine + images.Count * 2 + 4;
            int maxHeight = images.Max(img => img.Height) + 2;

            Bitmap finalImage = new Bitmap(totalWidth, maxHeight);

            using (Graphics g = Graphics.FromImage(finalImage))
            {
                int currentXPosition = 1;
                float currentYPosition = 1;

                g.DrawRectangle(new Pen(Color.Black), new RectangleF(0,0,totalWidth-1, maxHeight-1));

                foreach(string line in lines)
                {
                    g.DrawString(line, Font, new SolidBrush(ForeColor), currentXPosition, currentYPosition);
                    currentYPosition += highestHeigt + 2;
                }
                currentXPosition += longestLine + 4;

                foreach (Bitmap image in images)
                {
                    g.DrawImage(image, currentXPosition, 1);
                    currentXPosition += image.Width + 2;
                }
            }

            return finalImage;
        }

        private void Pb_Click(object sender, EventArgs e)
        {
            PictureBox pb = ((PictureBox)sender);
            pb.BackColor = new OSThemeColors().PrimaryDark;
            for(int i=0; i < flp_Compares.Controls.Count; i++)
            {
                if (flp_Compares.Controls[i] == pb)
                    SelectCompare?.Invoke(new Tuple<CResult, CResultCompare>(Result, Result.ComparableFiles[i]), EventArgs.Empty);
                else
                    flp_Compares.Controls[i].BackColor = pb_Main.BackColor;
            }
        }

        public void Deselect()
        {
            foreach(Control c in flp_Compares.Controls)
                c.BackColor = pb_Main.BackColor;
        }
    }
}
