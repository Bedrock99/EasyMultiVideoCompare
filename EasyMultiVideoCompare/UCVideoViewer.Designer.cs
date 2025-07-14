namespace EasyMultiVideoCompare
{
    partial class UCVideoViewer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pb_Video = new PictureBox();
            tb_MainVid = new TrackBar();
            splitContainer1 = new SplitContainer();
            gb_MainVid = new GroupBox();
            gb_CompareVid = new GroupBox();
            tb_CompareVid = new TrackBar();
            cb_MoveSlidersTogether = new CheckBox();
            cb_OneCompare = new CheckBox();
            cb_MakeImagesSameSize = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pb_Video).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tb_MainVid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            gb_MainVid.SuspendLayout();
            gb_CompareVid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tb_CompareVid).BeginInit();
            SuspendLayout();
            // 
            // pb_Video
            // 
            pb_Video.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pb_Video.BorderStyle = BorderStyle.FixedSingle;
            pb_Video.Location = new Point(0, 0);
            pb_Video.Margin = new Padding(0);
            pb_Video.Name = "pb_Video";
            pb_Video.Size = new Size(600, 133);
            pb_Video.SizeMode = PictureBoxSizeMode.Zoom;
            pb_Video.TabIndex = 0;
            pb_Video.TabStop = false;
            pb_Video.MouseLeave += pb_Video_MouseLeave;
            pb_Video.MouseMove += pb_Video_MouseMove;
            // 
            // tb_MainVid
            // 
            tb_MainVid.Dock = DockStyle.Fill;
            tb_MainVid.Location = new Point(3, 19);
            tb_MainVid.Name = "tb_MainVid";
            tb_MainVid.Size = new Size(279, 27);
            tb_MainVid.TabIndex = 1;
            tb_MainVid.TickFrequency = 0;
            tb_MainVid.TickStyle = TickStyle.None;
            tb_MainVid.Scroll += tb_MainVid_Scroll;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Bottom;
            splitContainer1.Location = new Point(0, 161);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(gb_MainVid);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(gb_CompareVid);
            splitContainer1.Size = new Size(600, 49);
            splitContainer1.SplitterDistance = 285;
            splitContainer1.TabIndex = 2;
            // 
            // gb_MainVid
            // 
            gb_MainVid.Controls.Add(tb_MainVid);
            gb_MainVid.Dock = DockStyle.Fill;
            gb_MainVid.Location = new Point(0, 0);
            gb_MainVid.Name = "gb_MainVid";
            gb_MainVid.Size = new Size(285, 49);
            gb_MainVid.TabIndex = 1;
            gb_MainVid.TabStop = false;
            // 
            // gb_CompareVid
            // 
            gb_CompareVid.Controls.Add(tb_CompareVid);
            gb_CompareVid.Dock = DockStyle.Fill;
            gb_CompareVid.Location = new Point(0, 0);
            gb_CompareVid.Name = "gb_CompareVid";
            gb_CompareVid.Size = new Size(311, 49);
            gb_CompareVid.TabIndex = 0;
            gb_CompareVid.TabStop = false;
            // 
            // tb_CompareVid
            // 
            tb_CompareVid.Dock = DockStyle.Fill;
            tb_CompareVid.Location = new Point(3, 19);
            tb_CompareVid.Name = "tb_CompareVid";
            tb_CompareVid.Size = new Size(305, 27);
            tb_CompareVid.TabIndex = 2;
            tb_CompareVid.TickFrequency = 0;
            tb_CompareVid.TickStyle = TickStyle.None;
            tb_CompareVid.Scroll += tb_CompareVid_Scroll;
            // 
            // cb_MoveSlidersTogether
            // 
            cb_MoveSlidersTogether.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cb_MoveSlidersTogether.AutoSize = true;
            cb_MoveSlidersTogether.Location = new Point(457, 136);
            cb_MoveSlidersTogether.Name = "cb_MoveSlidersTogether";
            cb_MoveSlidersTogether.Size = new Size(140, 19);
            cb_MoveSlidersTogether.TabIndex = 3;
            cb_MoveSlidersTogether.Text = "Move sliders together";
            cb_MoveSlidersTogether.UseVisualStyleBackColor = true;
            // 
            // cb_OneCompare
            // 
            cb_OneCompare.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cb_OneCompare.AutoSize = true;
            cb_OneCompare.Location = new Point(3, 136);
            cb_OneCompare.Name = "cb_OneCompare";
            cb_OneCompare.Size = new Size(293, 19);
            cb_OneCompare.TabIndex = 4;
            cb_OneCompare.Text = "Use one compare image (else 2 next to each other)";
            cb_OneCompare.UseVisualStyleBackColor = true;
            cb_OneCompare.CheckedChanged += cb_OneCompare_CheckedChanged;
            // 
            // cb_MakeImagesSameSize
            // 
            cb_MakeImagesSameSize.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cb_MakeImagesSameSize.AutoSize = true;
            cb_MakeImagesSameSize.Location = new Point(302, 136);
            cb_MakeImagesSameSize.Name = "cb_MakeImagesSameSize";
            cb_MakeImagesSameSize.Size = new Size(149, 19);
            cb_MakeImagesSameSize.TabIndex = 5;
            cb_MakeImagesSameSize.Text = "Make images same size";
            cb_MakeImagesSameSize.UseVisualStyleBackColor = true;
            cb_MakeImagesSameSize.CheckedChanged += cb_MakeImagesSameSize_CheckedChanged;
            // 
            // UCVideoViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cb_MakeImagesSameSize);
            Controls.Add(cb_OneCompare);
            Controls.Add(cb_MoveSlidersTogether);
            Controls.Add(splitContainer1);
            Controls.Add(pb_Video);
            MinimumSize = new Size(600, 200);
            Name = "UCVideoViewer";
            Size = new Size(600, 210);
            ((System.ComponentModel.ISupportInitialize)pb_Video).EndInit();
            ((System.ComponentModel.ISupportInitialize)tb_MainVid).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            gb_MainVid.ResumeLayout(false);
            gb_MainVid.PerformLayout();
            gb_CompareVid.ResumeLayout(false);
            gb_CompareVid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tb_CompareVid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pb_Video;
        private TrackBar tb_MainVid;
        private SplitContainer splitContainer1;
        private GroupBox gb_MainVid;
        private GroupBox gb_CompareVid;
        private TrackBar tb_CompareVid;
        private CheckBox cb_MoveSlidersTogether;
        private CheckBox cb_OneCompare;
        private CheckBox cb_MakeImagesSameSize;
    }
}
