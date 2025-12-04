namespace EasyMultiVideoCompare
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tc_Main = new TabControl();
            tp_Selection = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            btn_Run = new Button();
            btn_Options = new Button();
            btn_RemoveSelectedFolder = new Button();
            lb_Folders = new ListBox();
            btn_AddFolder = new Button();
            tb_Run = new TabPage();
            tableLayoutPanel2 = new TableLayoutPanel();
            lpb_RunProgressOverall = new LabeledProgressBar();
            lpb_RunProgressCompare = new LabeledProgressBar();
            lpb_RunProgressCreateHashes = new LabeledProgressBar();
            tb_Log = new TextBox();
            tp_Results = new TabPage();
            splitContainer1 = new SplitContainer();
            groupBox2 = new GroupBox();
            flp_Results = new FlowLayoutPanel();
            groupBox1 = new GroupBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            splitContainer2 = new SplitContainer();
            tv_ResultFile1 = new TreeView();
            tv_ResultFile2 = new TreeView();
            tabPage2 = new TabPage();
            ucVideoViewer1 = new UCVideoViewer();
            statusStrip1 = new StatusStrip();
            tssl_ResultsState = new ToolStripStatusLabel();
            Timer_Resize = new System.Windows.Forms.Timer(components);
            tc_Main.SuspendLayout();
            tp_Selection.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tb_Run.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tp_Results.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            tabPage2.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tc_Main
            // 
            tc_Main.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tc_Main.Controls.Add(tp_Selection);
            tc_Main.Controls.Add(tb_Run);
            tc_Main.Controls.Add(tp_Results);
            tc_Main.Location = new Point(12, 12);
            tc_Main.Name = "tc_Main";
            tc_Main.SelectedIndex = 0;
            tc_Main.Size = new Size(760, 324);
            tc_Main.TabIndex = 0;
            // 
            // tp_Selection
            // 
            tp_Selection.Controls.Add(tableLayoutPanel1);
            tp_Selection.Location = new Point(4, 24);
            tp_Selection.Name = "tp_Selection";
            tp_Selection.Padding = new Padding(3);
            tp_Selection.Size = new Size(752, 296);
            tp_Selection.TabIndex = 0;
            tp_Selection.Text = "Selection";
            tp_Selection.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tableLayoutPanel1.Controls.Add(btn_Run, 1, 3);
            tableLayoutPanel1.Controls.Add(btn_Options, 1, 2);
            tableLayoutPanel1.Controls.Add(btn_RemoveSelectedFolder, 1, 1);
            tableLayoutPanel1.Controls.Add(lb_Folders, 0, 0);
            tableLayoutPanel1.Controls.Add(btn_AddFolder, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Size = new Size(746, 290);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // btn_Run
            // 
            btn_Run.Dock = DockStyle.Fill;
            btn_Run.Location = new Point(599, 219);
            btn_Run.Name = "btn_Run";
            btn_Run.Size = new Size(144, 68);
            btn_Run.TabIndex = 4;
            btn_Run.Text = "Run comparision";
            btn_Run.UseVisualStyleBackColor = true;
            btn_Run.Click += btn_Run_Click;
            // 
            // btn_Options
            // 
            btn_Options.Dock = DockStyle.Fill;
            btn_Options.Location = new Point(599, 147);
            btn_Options.Name = "btn_Options";
            btn_Options.Size = new Size(144, 66);
            btn_Options.TabIndex = 3;
            btn_Options.Text = "Settings";
            btn_Options.UseVisualStyleBackColor = true;
            btn_Options.Click += btn_Options_Click;
            // 
            // btn_RemoveSelectedFolder
            // 
            btn_RemoveSelectedFolder.Dock = DockStyle.Fill;
            btn_RemoveSelectedFolder.Location = new Point(599, 75);
            btn_RemoveSelectedFolder.Name = "btn_RemoveSelectedFolder";
            btn_RemoveSelectedFolder.Size = new Size(144, 66);
            btn_RemoveSelectedFolder.TabIndex = 2;
            btn_RemoveSelectedFolder.Text = "Remove selected folder";
            btn_RemoveSelectedFolder.UseVisualStyleBackColor = true;
            btn_RemoveSelectedFolder.Click += btn_RemoveSelectedFolder_Click;
            // 
            // lb_Folders
            // 
            lb_Folders.Dock = DockStyle.Fill;
            lb_Folders.FormattingEnabled = true;
            lb_Folders.Location = new Point(3, 3);
            lb_Folders.Name = "lb_Folders";
            tableLayoutPanel1.SetRowSpan(lb_Folders, 4);
            lb_Folders.ScrollAlwaysVisible = true;
            lb_Folders.Size = new Size(590, 284);
            lb_Folders.TabIndex = 0;
            // 
            // btn_AddFolder
            // 
            btn_AddFolder.Dock = DockStyle.Fill;
            btn_AddFolder.Location = new Point(599, 3);
            btn_AddFolder.Name = "btn_AddFolder";
            btn_AddFolder.Size = new Size(144, 66);
            btn_AddFolder.TabIndex = 1;
            btn_AddFolder.Text = "Add folder";
            btn_AddFolder.UseVisualStyleBackColor = true;
            btn_AddFolder.Click += btn_AddFolder_Click;
            // 
            // tb_Run
            // 
            tb_Run.Controls.Add(tableLayoutPanel2);
            tb_Run.Controls.Add(tb_Log);
            tb_Run.Location = new Point(4, 24);
            tb_Run.Name = "tb_Run";
            tb_Run.Padding = new Padding(3);
            tb_Run.Size = new Size(752, 296);
            tb_Run.TabIndex = 1;
            tb_Run.Text = "Run";
            tb_Run.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(lpb_RunProgressOverall, 0, 0);
            tableLayoutPanel2.Controls.Add(lpb_RunProgressCompare, 1, 1);
            tableLayoutPanel2.Controls.Add(lpb_RunProgressCreateHashes, 0, 1);
            tableLayoutPanel2.Location = new Point(6, 6);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(740, 54);
            tableLayoutPanel2.TabIndex = 4;
            // 
            // lpb_RunProgressOverall
            // 
            lpb_RunProgressOverall.AddTextBefore = "Overall";
            tableLayoutPanel2.SetColumnSpan(lpb_RunProgressOverall, 2);
            lpb_RunProgressOverall.Dock = DockStyle.Fill;
            lpb_RunProgressOverall.Location = new Point(3, 3);
            lpb_RunProgressOverall.Maximum = 20000;
            lpb_RunProgressOverall.Name = "lpb_RunProgressOverall";
            lpb_RunProgressOverall.Size = new Size(734, 21);
            lpb_RunProgressOverall.TabIndex = 3;
            // 
            // lpb_RunProgressCompare
            // 
            lpb_RunProgressCompare.AddTextBefore = "Compare";
            lpb_RunProgressCompare.Dock = DockStyle.Fill;
            lpb_RunProgressCompare.Location = new Point(373, 30);
            lpb_RunProgressCompare.Maximum = 10000;
            lpb_RunProgressCompare.Name = "lpb_RunProgressCompare";
            lpb_RunProgressCompare.Size = new Size(364, 21);
            lpb_RunProgressCompare.TabIndex = 2;
            // 
            // lpb_RunProgressCreateHashes
            // 
            lpb_RunProgressCreateHashes.AddTextBefore = "Create Hashes";
            lpb_RunProgressCreateHashes.Dock = DockStyle.Fill;
            lpb_RunProgressCreateHashes.Location = new Point(3, 30);
            lpb_RunProgressCreateHashes.Maximum = 10000;
            lpb_RunProgressCreateHashes.Name = "lpb_RunProgressCreateHashes";
            lpb_RunProgressCreateHashes.Size = new Size(364, 21);
            lpb_RunProgressCreateHashes.TabIndex = 0;
            // 
            // tb_Log
            // 
            tb_Log.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tb_Log.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_Log.Location = new Point(6, 66);
            tb_Log.Multiline = true;
            tb_Log.Name = "tb_Log";
            tb_Log.ReadOnly = true;
            tb_Log.ScrollBars = ScrollBars.Both;
            tb_Log.Size = new Size(740, 224);
            tb_Log.TabIndex = 1;
            tb_Log.WordWrap = false;
            // 
            // tp_Results
            // 
            tp_Results.Controls.Add(splitContainer1);
            tp_Results.Location = new Point(4, 24);
            tp_Results.Name = "tp_Results";
            tp_Results.Size = new Size(752, 296);
            tp_Results.TabIndex = 2;
            tp_Results.Text = "Results";
            tp_Results.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox1);
            splitContainer1.Panel2MinSize = 620;
            splitContainer1.Size = new Size(752, 296);
            splitContainer1.SplitterDistance = 128;
            splitContainer1.TabIndex = 3;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(flp_Results);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(128, 296);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Found duplicates:";
            // 
            // flp_Results
            // 
            flp_Results.AutoScroll = true;
            flp_Results.Dock = DockStyle.Fill;
            flp_Results.FlowDirection = FlowDirection.TopDown;
            flp_Results.Location = new Point(3, 19);
            flp_Results.Name = "flp_Results";
            flp_Results.Size = new Size(122, 274);
            flp_Results.TabIndex = 0;
            flp_Results.WrapContents = false;
            flp_Results.Resize += flp_Results_Resize;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tabControl1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(620, 296);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Compare selected duplicates:";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(3, 19);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(614, 274);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(splitContainer2);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(606, 246);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "File informations";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            splitContainer2.BackColor = Color.Transparent;
            splitContainer2.BorderStyle = BorderStyle.FixedSingle;
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(3, 3);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(tv_ResultFile1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(tv_ResultFile2);
            splitContainer2.Size = new Size(600, 240);
            splitContainer2.SplitterDistance = 117;
            splitContainer2.TabIndex = 2;
            // 
            // tv_ResultFile1
            // 
            tv_ResultFile1.Dock = DockStyle.Fill;
            tv_ResultFile1.Location = new Point(0, 0);
            tv_ResultFile1.Name = "tv_ResultFile1";
            tv_ResultFile1.Size = new Size(598, 115);
            tv_ResultFile1.TabIndex = 0;
            // 
            // tv_ResultFile2
            // 
            tv_ResultFile2.Dock = DockStyle.Fill;
            tv_ResultFile2.Location = new Point(0, 0);
            tv_ResultFile2.Name = "tv_ResultFile2";
            tv_ResultFile2.Size = new Size(598, 117);
            tv_ResultFile2.TabIndex = 1;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(ucVideoViewer1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(606, 246);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Video comparision";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // ucVideoViewer1
            // 
            ucVideoViewer1.Dock = DockStyle.Fill;
            ucVideoViewer1.Location = new Point(3, 3);
            ucVideoViewer1.MinimumSize = new Size(600, 200);
            ucVideoViewer1.Name = "ucVideoViewer1";
            ucVideoViewer1.Size = new Size(600, 240);
            ucVideoViewer1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { tssl_ResultsState });
            statusStrip1.Location = new Point(0, 339);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(784, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // tssl_ResultsState
            // 
            tssl_ResultsState.Name = "tssl_ResultsState";
            tssl_ResultsState.Size = new Size(97, 17);
            tssl_ResultsState.Text = "Results state: idle";
            // 
            // Timer_Resize
            // 
            Timer_Resize.Tick += Timer_Resize_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 361);
            Controls.Add(statusStrip1);
            Controls.Add(tc_Main);
            MinimumSize = new Size(800, 400);
            Name = "Form1";
            Text = "EasyVideoMultiCompare";
            FormClosing += Form1_FormClosing;
            Shown += Form1_Shown;
            tc_Main.ResumeLayout(false);
            tp_Selection.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tb_Run.ResumeLayout(false);
            tb_Run.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tp_Results.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tc_Main;
        private TabPage tp_Selection;
        private ListBox lb_Folders;
        private TabPage tb_Run;
        private StatusStrip statusStrip1;
        private TableLayoutPanel tableLayoutPanel1;
        private ToolStripStatusLabel tssl_ResultsState;
        private TabPage tp_Results;
        private Button btn_Run;
        private Button btn_Options;
        private Button btn_RemoveSelectedFolder;
        private Button btn_AddFolder;
        private LabeledProgressBar lpb_RunProgressCreateHashes;
        private TextBox tb_Log;
        private SplitContainer splitContainer1;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private SplitContainer splitContainer2;
        private TreeView tv_ResultFile1;
        private TreeView tv_ResultFile2;
        private UCVideoViewer ucVideoViewer1;
        private LabeledProgressBar lpb_RunProgressCompare;
        private TableLayoutPanel tableLayoutPanel2;
        private LabeledProgressBar lpb_RunProgressOverall;
        private FlowLayoutPanel flp_Results;
        private System.Windows.Forms.Timer Timer_Resize;
    }
}
