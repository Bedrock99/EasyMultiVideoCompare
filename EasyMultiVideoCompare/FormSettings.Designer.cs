namespace EasyMultiVideoCompare
{
    partial class FormSettings
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_Ok = new Button();
            btn_Abort = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            nud_PreviewBitmapCount = new NumericUpDown();
            cb_SearchRecursive = new CheckBox();
            cb_SaveAndLoadCompareHashesOnDisk = new CheckBox();
            groupBox2 = new GroupBox();
            groupBox6 = new GroupBox();
            tb_AddFileType = new TextBox();
            btn_AddFileType = new Button();
            btn_RemoveSelectedFileType = new Button();
            lb_FileTypes = new ListBox();
            groupBox3 = new GroupBox();
            nud_PreviewBitmapSize = new NumericUpDown();
            groupBox4 = new GroupBox();
            nud_MaxHammingDistance = new NumericUpDown();
            groupBox5 = new GroupBox();
            nud_MinMatchRatio = new NumericUpDown();
            tableLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nud_PreviewBitmapCount).BeginInit();
            groupBox2.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nud_PreviewBitmapSize).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nud_MaxHammingDistance).BeginInit();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nud_MinMatchRatio).BeginInit();
            SuspendLayout();
            // 
            // btn_Ok
            // 
            btn_Ok.Dock = DockStyle.Fill;
            btn_Ok.Location = new Point(161, 3);
            btn_Ok.Name = "btn_Ok";
            btn_Ok.Size = new Size(152, 22);
            btn_Ok.TabIndex = 0;
            btn_Ok.Text = "Save";
            btn_Ok.UseVisualStyleBackColor = true;
            btn_Ok.Click += btn_Ok_Click;
            // 
            // btn_Abort
            // 
            btn_Abort.Dock = DockStyle.Fill;
            btn_Abort.Location = new Point(3, 3);
            btn_Abort.Name = "btn_Abort";
            btn_Abort.Size = new Size(152, 22);
            btn_Abort.TabIndex = 1;
            btn_Abort.Text = "Abort";
            btn_Abort.UseVisualStyleBackColor = true;
            btn_Abort.Click += btn_Abort_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(btn_Abort, 0, 0);
            tableLayoutPanel1.Controls.Add(btn_Ok, 1, 0);
            tableLayoutPanel1.Location = new Point(12, 409);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(316, 28);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(nud_PreviewBitmapCount);
            groupBox1.Location = new Point(12, 303);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(316, 47);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Results - Preview Image Count:";
            // 
            // nud_PreviewBitmapCount
            // 
            nud_PreviewBitmapCount.Dock = DockStyle.Fill;
            nud_PreviewBitmapCount.Location = new Point(3, 19);
            nud_PreviewBitmapCount.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nud_PreviewBitmapCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nud_PreviewBitmapCount.Name = "nud_PreviewBitmapCount";
            nud_PreviewBitmapCount.Size = new Size(310, 23);
            nud_PreviewBitmapCount.TabIndex = 4;
            nud_PreviewBitmapCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cb_SearchRecursive
            // 
            cb_SearchRecursive.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cb_SearchRecursive.AutoSize = true;
            cb_SearchRecursive.Location = new Point(12, 147);
            cb_SearchRecursive.Name = "cb_SearchRecursive";
            cb_SearchRecursive.Size = new Size(160, 19);
            cb_SearchRecursive.TabIndex = 5;
            cb_SearchRecursive.Text = "Search - Recursive Search";
            cb_SearchRecursive.UseVisualStyleBackColor = true;
            // 
            // cb_SaveAndLoadCompareHashesOnDisk
            // 
            cb_SaveAndLoadCompareHashesOnDisk.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cb_SaveAndLoadCompareHashesOnDisk.AutoSize = true;
            cb_SaveAndLoadCompareHashesOnDisk.Location = new Point(12, 172);
            cb_SaveAndLoadCompareHashesOnDisk.Name = "cb_SaveAndLoadCompareHashesOnDisk";
            cb_SaveAndLoadCompareHashesOnDisk.Size = new Size(269, 19);
            cb_SaveAndLoadCompareHashesOnDisk.TabIndex = 6;
            cb_SaveAndLoadCompareHashesOnDisk.Text = "Compare Hashes - Save and load to/from disk";
            cb_SaveAndLoadCompareHashesOnDisk.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(groupBox6);
            groupBox2.Controls.Add(btn_RemoveSelectedFileType);
            groupBox2.Controls.Add(lb_FileTypes);
            groupBox2.Location = new Point(12, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(316, 129);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Search - Valid file types:";
            // 
            // groupBox6
            // 
            groupBox6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox6.Controls.Add(tb_AddFileType);
            groupBox6.Controls.Add(btn_AddFileType);
            groupBox6.Location = new Point(158, 14);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(152, 74);
            groupBox6.TabIndex = 2;
            groupBox6.TabStop = false;
            // 
            // tb_AddFileType
            // 
            tb_AddFileType.Dock = DockStyle.Top;
            tb_AddFileType.Location = new Point(3, 19);
            tb_AddFileType.Name = "tb_AddFileType";
            tb_AddFileType.Size = new Size(146, 23);
            tb_AddFileType.TabIndex = 4;
            // 
            // btn_AddFileType
            // 
            btn_AddFileType.Dock = DockStyle.Bottom;
            btn_AddFileType.Location = new Point(3, 48);
            btn_AddFileType.Name = "btn_AddFileType";
            btn_AddFileType.Size = new Size(146, 23);
            btn_AddFileType.TabIndex = 3;
            btn_AddFileType.Text = "Add file type";
            btn_AddFileType.UseVisualStyleBackColor = true;
            btn_AddFileType.Click += btn_AddFileType_Click;
            // 
            // btn_RemoveSelectedFileType
            // 
            btn_RemoveSelectedFileType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_RemoveSelectedFileType.Location = new Point(158, 94);
            btn_RemoveSelectedFileType.Name = "btn_RemoveSelectedFileType";
            btn_RemoveSelectedFileType.Size = new Size(152, 23);
            btn_RemoveSelectedFileType.TabIndex = 1;
            btn_RemoveSelectedFileType.Text = "Remove selected file type";
            btn_RemoveSelectedFileType.UseVisualStyleBackColor = true;
            btn_RemoveSelectedFileType.Click += btn_RemoveSelectedFileType_Click;
            // 
            // lb_FileTypes
            // 
            lb_FileTypes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lb_FileTypes.FormattingEnabled = true;
            lb_FileTypes.Location = new Point(6, 22);
            lb_FileTypes.Name = "lb_FileTypes";
            lb_FileTypes.Size = new Size(146, 94);
            lb_FileTypes.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(nud_PreviewBitmapSize);
            groupBox3.Location = new Point(12, 356);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(316, 47);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "Results - Preview Image Height:";
            // 
            // nud_PreviewBitmapSize
            // 
            nud_PreviewBitmapSize.Dock = DockStyle.Fill;
            nud_PreviewBitmapSize.Location = new Point(3, 19);
            nud_PreviewBitmapSize.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nud_PreviewBitmapSize.Minimum = new decimal(new int[] { 18, 0, 0, 0 });
            nud_PreviewBitmapSize.Name = "nud_PreviewBitmapSize";
            nud_PreviewBitmapSize.Size = new Size(310, 23);
            nud_PreviewBitmapSize.TabIndex = 4;
            nud_PreviewBitmapSize.Value = new decimal(new int[] { 18, 0, 0, 0 });
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox4.Controls.Add(nud_MaxHammingDistance);
            groupBox4.Location = new Point(12, 197);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(316, 47);
            groupBox4.TabIndex = 6;
            groupBox4.TabStop = false;
            groupBox4.Text = "Compare - Maximal hamming distance:";
            // 
            // nud_MaxHammingDistance
            // 
            nud_MaxHammingDistance.Dock = DockStyle.Fill;
            nud_MaxHammingDistance.Location = new Point(3, 19);
            nud_MaxHammingDistance.Name = "nud_MaxHammingDistance";
            nud_MaxHammingDistance.Size = new Size(310, 23);
            nud_MaxHammingDistance.TabIndex = 4;
            // 
            // groupBox5
            // 
            groupBox5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox5.Controls.Add(nud_MinMatchRatio);
            groupBox5.Location = new Point(12, 250);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(316, 47);
            groupBox5.TabIndex = 7;
            groupBox5.TabStop = false;
            groupBox5.Text = "Compare - Minimal match ratio:";
            // 
            // nud_MinMatchRatio
            // 
            nud_MinMatchRatio.DecimalPlaces = 2;
            nud_MinMatchRatio.Dock = DockStyle.Fill;
            nud_MinMatchRatio.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            nud_MinMatchRatio.Location = new Point(3, 19);
            nud_MinMatchRatio.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nud_MinMatchRatio.Name = "nud_MinMatchRatio";
            nud_MinMatchRatio.Size = new Size(310, 23);
            nud_MinMatchRatio.TabIndex = 4;
            // 
            // FormSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(340, 449);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(cb_SaveAndLoadCompareHashesOnDisk);
            Controls.Add(cb_SearchRecursive);
            Controls.Add(groupBox1);
            Controls.Add(tableLayoutPanel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormSettings";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            FormClosing += FormSettings_FormClosing;
            tableLayoutPanel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nud_PreviewBitmapCount).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nud_PreviewBitmapSize).EndInit();
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nud_MaxHammingDistance).EndInit();
            groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nud_MinMatchRatio).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Ok;
        private Button btn_Abort;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox1;
        private NumericUpDown nud_PreviewBitmapCount;
        private CheckBox cb_SearchRecursive;
        private CheckBox cb_SaveAndLoadCompareHashesOnDisk;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private NumericUpDown nud_PreviewBitmapSize;
        private GroupBox groupBox4;
        private NumericUpDown nud_MaxHammingDistance;
        private GroupBox groupBox5;
        private NumericUpDown nud_MinMatchRatio;
        private ListBox lb_FileTypes;
        private GroupBox groupBox6;
        private TextBox tb_AddFileType;
        private Button btn_AddFileType;
        private Button btn_RemoveSelectedFileType;
    }
}