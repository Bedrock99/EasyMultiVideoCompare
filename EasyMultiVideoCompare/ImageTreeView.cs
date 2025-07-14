namespace EasyMultiVideoCompare
{
    public class ImageTreeView : TreeView
    {
        #region --- Constructor ---

        public ImageTreeView()
        {
            DrawMode = TreeViewDrawMode.OwnerDrawAll;
            DrawNode += ImageTreeView_DrawNode;
        }

        #endregion

        #region --- DrawNode ---

        private void ImageTreeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            CResult nodeDataResult = null;
            CResultCompare nodeDataCompare = null;
            if (e.Node.Tag.GetType() == typeof(CResult))
                nodeDataResult = e.Node.Tag as CResult;
            else if(e.Node.Tag.GetType() == typeof(CResultCompare))
                nodeDataCompare = e.Node.Tag as CResultCompare;

            //no data -> just show (bitmaps are loladed before show
            if (nodeDataResult == null && nodeDataCompare == null)
            {
                e.DrawDefault = true;
                return;
            }

            Graphics g = e.Graphics;
            Rectangle bounds = e.Bounds;

            //paint background
            Brush backgroundBrush;
            if ((e.State & TreeNodeStates.Selected) != 0)
                backgroundBrush = SystemBrushes.Highlight;
            else if ((e.State & TreeNodeStates.Hot) != 0)
                backgroundBrush = SystemBrushes.ControlLight;
            else
                backgroundBrush = SystemBrushes.Window;
            g.FillRectangle(backgroundBrush, bounds);

            //calculate start and paint +/- if needed
            int currentX = bounds.X + (e.Node.Level * this.Indent);
            if (e.Node.Nodes.Count > 0)
            {
                Point plusMinusPoint = new Point(
                    bounds.X + (e.Node.Level * this.Indent) + 8,
                    bounds.Y + (bounds.Height - 9) / 2);

                DrawPlusMinus(g, plusMinusPoint, e.Node.IsExpanded);
            }
            currentX += 20;

            //get data
            int imagePadding = 2;
            CVideoFile fil = null;
            string hamm = "";
            string count = "";
            if (nodeDataResult != null)
            {
                fil = nodeDataResult.File;
                count = " (" + nodeDataResult.ComparableFiles.Count.ToString() + ")";
            }
            else
            {
                fil = nodeDataCompare.File;
                hamm = nodeDataCompare.HammingDistance.ToString("0.000") + " - ";
            }

            //paint images
            foreach (Image img in fil.Bitmaps)
            {
                int imgHeight = img.Height;
                int imgWidth = img.Width;

                int y = bounds.Y + (bounds.Height - imgHeight) / 2;

                g.DrawImage(img, currentX, y, imgWidth, imgHeight);
                currentX += imgWidth + imagePadding;
            }

            //paint text
            Color textColor = SystemColors.ControlText;
            if ((e.State & TreeNodeStates.Selected) != 0)
                textColor = SystemColors.HighlightText;

            string nodeDisplayText = (hamm + fil.GeneralInfo.Name + count) ?? e.Node.Text;

            TextRenderer.DrawText(g, nodeDisplayText, e.Node.NodeFont,
                                  new Rectangle(currentX, bounds.Y, bounds.Width - currentX, bounds.Height),
                                  textColor, TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

            //paint focus rectangle if in focus
            if ((e.State & TreeNodeStates.Focused) != 0)
                ControlPaint.DrawFocusRectangle(g, bounds, textColor, backgroundBrush.GetType() == typeof(SolidBrush) ? 
                    ((SolidBrush)backgroundBrush).Color : Color.Empty);
        }

        #endregion

        #region --- DrawplusMinus ---

        private void DrawPlusMinus(Graphics g, Point location, bool isExpanded)
        {
            int size = 9;
            Rectangle rect = new Rectangle(location.X, location.Y, size, size);

            g.FillRectangle(Brushes.White, rect);
            g.DrawRectangle(Pens.Gray, rect);

            g.DrawLine(Pens.Black, rect.X + 2, rect.Y + size / 2, rect.X + size - 3, rect.Y + size / 2);

            if (!isExpanded)
                g.DrawLine(Pens.Black, rect.X + size / 2, rect.Y + 2, rect.X + size / 2, rect.Y + size - 3);
        }

        #endregion
    }
}
