namespace gui
{
    partial class VideoViewForm
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
            this.searchVideoFileHistoryPanel1 = new gui.SearchVideoFileHistoryPanel();
            this.videoPlayerPanel1 = new gui.VideoPlayerPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchVideoFileHistoryPanel1
            // 
            this.searchVideoFileHistoryPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchVideoFileHistoryPanel1.Location = new System.Drawing.Point(0, 0);
            this.searchVideoFileHistoryPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.searchVideoFileHistoryPanel1.Name = "searchVideoFileHistoryPanel1";
            this.searchVideoFileHistoryPanel1.Size = new System.Drawing.Size(728, 1327);
            this.searchVideoFileHistoryPanel1.TabIndex = 0;
            // 
            // videoPlayerPanel1
            // 
            this.videoPlayerPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.videoPlayerPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoPlayerPanel1.Location = new System.Drawing.Point(0, 0);
            this.videoPlayerPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.videoPlayerPanel1.Name = "videoPlayerPanel1";
            this.videoPlayerPanel1.Ratio = 0.75D;
            this.videoPlayerPanel1.Size = new System.Drawing.Size(1832, 1327);
            this.videoPlayerPanel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.searchVideoFileHistoryPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.videoPlayerPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(2564, 1327);
            this.splitContainer1.SplitterDistance = 728;
            this.splitContainer1.TabIndex = 2;
            // 
            // VideoViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2564, 1327);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VideoViewForm";
            this.Text = "Архив Видео";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VideoViewForm_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private gui.SearchVideoFileHistoryPanel searchVideoFileHistoryPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private gui.VideoPlayerPanel videoPlayerPanel1;

        #endregion
    }
}