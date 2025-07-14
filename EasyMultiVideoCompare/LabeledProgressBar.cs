#region Using...

using System.Drawing.Text;

#endregion

namespace EasyMultiVideoCompare
{
    public class LabeledProgressBar : ProgressBar
    {
        #region --- Constructor ---

        public LabeledProgressBar()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
        }

        #endregion

        #region --- OnPaint ---

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = ClientRectangle;

            g.TextRenderingHint = TextRenderingHint.AntiAlias;

            ProgressBarRenderer.DrawHorizontalBar(g, rect);
            rect.Width = (int)(rect.Width * ((double)Value / Maximum));
            ProgressBarRenderer.DrawHorizontalChunks(g, rect);

            string text = $"{((double)Value/Maximum*100):0.00} %";

            using (StringFormat sf = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            })
            {
                Brush textBrush = Brushes.Black;
                g.DrawString(text, Font, textBrush, ClientRectangle, sf);
            }
        }

        #endregion
    }
}