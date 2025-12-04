namespace EasyMultiVideoCompare
{
    partial class UCResult
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
            btn_Expand = new Button();
            pb_Main = new PictureBox();
            flp_Compares = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pb_Main).BeginInit();
            SuspendLayout();
            // 
            // btn_Expand
            // 
            btn_Expand.Enabled = false;
            btn_Expand.Location = new Point(3, 18);
            btn_Expand.Name = "btn_Expand";
            btn_Expand.Size = new Size(24, 25);
            btn_Expand.TabIndex = 0;
            btn_Expand.Text = "+";
            btn_Expand.UseVisualStyleBackColor = true;
            btn_Expand.Click += btn_Expand_Click;
            // 
            // pb_Main
            // 
            pb_Main.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pb_Main.BorderStyle = BorderStyle.FixedSingle;
            pb_Main.Image = Resources.loading;
            pb_Main.Location = new Point(31, 3);
            pb_Main.Name = "pb_Main";
            pb_Main.Size = new Size(257, 50);
            pb_Main.SizeMode = PictureBoxSizeMode.Zoom;
            pb_Main.TabIndex = 1;
            pb_Main.TabStop = false;
            // 
            // flp_Compares
            // 
            flp_Compares.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flp_Compares.BorderStyle = BorderStyle.FixedSingle;
            flp_Compares.FlowDirection = FlowDirection.TopDown;
            flp_Compares.Location = new Point(3, 59);
            flp_Compares.Name = "flp_Compares";
            flp_Compares.Size = new Size(285, 88);
            flp_Compares.TabIndex = 2;
            flp_Compares.WrapContents = false;
            // 
            // UCResult
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flp_Compares);
            Controls.Add(pb_Main);
            Controls.Add(btn_Expand);
            Name = "UCResult";
            Size = new Size(291, 150);
            Load += UCResult_Load;
            ((System.ComponentModel.ISupportInitialize)pb_Main).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Expand;
        private PictureBox pb_Main;
        private FlowLayoutPanel flp_Compares;
    }
}
