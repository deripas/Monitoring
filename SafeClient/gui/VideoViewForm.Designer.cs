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
            this.panel1 = new System.Windows.Forms.Panel();
            this.videoPlayerPanel1 = new gui.VideoPlayerPanel();
            this.searchVideoFileHistoryPanel1 = new gui.SearchVideoFileHistoryPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.searchVideoFileHistoryPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 684);
            this.panel1.TabIndex = 1;
            // 
            // videoPlayerPanel1
            // 
            this.videoPlayerPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoPlayerPanel1.Location = new System.Drawing.Point(360, 0);
            this.videoPlayerPanel1.Name = "videoPlayerPanel1";
            this.videoPlayerPanel1.Ratio = 0.75D;
            this.videoPlayerPanel1.Size = new System.Drawing.Size(1048, 684);
            this.videoPlayerPanel1.TabIndex = 0;
            // 
            // searchVideoFileHistoryPanel1
            // 
            this.searchVideoFileHistoryPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchVideoFileHistoryPanel1.Location = new System.Drawing.Point(0, 0);
            this.searchVideoFileHistoryPanel1.Name = "searchVideoFileHistoryPanel1";
            this.searchVideoFileHistoryPanel1.Size = new System.Drawing.Size(360, 684);
            this.searchVideoFileHistoryPanel1.TabIndex = 0;
            // 
            // VideoViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1408, 684);
            this.Controls.Add(this.videoPlayerPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "VideoViewForm";
            this.Text = "VideoViewForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VideoViewForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private VideoPlayerPanel videoPlayerPanel1;
        private System.Windows.Forms.Panel panel1;
        private SearchVideoFileHistoryPanel searchVideoFileHistoryPanel1;
    }
}