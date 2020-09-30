namespace gui
{
    partial class AlertViewForm
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
            this.alertPlayerPanel1 = new gui.AlertPlayerPanel();
            this.searchAlertPanel1 = new gui.SearchAlertPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // alertPlayerPanel1
            // 
            this.alertPlayerPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.alertPlayerPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alertPlayerPanel1.Location = new System.Drawing.Point(0, 0);
            this.alertPlayerPanel1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.alertPlayerPanel1.Name = "alertPlayerPanel1";
            this.alertPlayerPanel1.Ratio = 0.75D;
            this.alertPlayerPanel1.Size = new System.Drawing.Size(1035, 679);
            this.alertPlayerPanel1.TabIndex = 0;
            // 
            // searchAlertPanel1
            // 
            this.searchAlertPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchAlertPanel1.Location = new System.Drawing.Point(0, 0);
            this.searchAlertPanel1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.searchAlertPanel1.Name = "searchAlertPanel1";
            this.searchAlertPanel1.Size = new System.Drawing.Size(443, 679);
            this.searchAlertPanel1.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.searchAlertPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.alertPlayerPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1480, 679);
            this.splitContainer1.SplitterDistance = 443;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 2;
            // 
            // AlertViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1480, 679);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlertViewForm";
            this.Text = "AlertViewForm";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlertViewForm_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AlertPlayerPanel alertPlayerPanel1;
        private SearchAlertPanel searchAlertPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}