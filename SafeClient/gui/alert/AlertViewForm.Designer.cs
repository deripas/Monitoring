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
            this.SuspendLayout();
            // 
            // alertPlayerPanel1
            // 
            this.alertPlayerPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alertPlayerPanel1.Location = new System.Drawing.Point(454, 0);
            this.alertPlayerPanel1.Name = "alertPlayerPanel1";
            this.alertPlayerPanel1.Ratio = 0.75D;
            this.alertPlayerPanel1.Size = new System.Drawing.Size(901, 840);
            this.alertPlayerPanel1.TabIndex = 0;
            // 
            // searchAlertPanel1
            // 
            this.searchAlertPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.searchAlertPanel1.Location = new System.Drawing.Point(0, 0);
            this.searchAlertPanel1.Name = "searchAlertPanel1";
            this.searchAlertPanel1.Size = new System.Drawing.Size(454, 840);
            this.searchAlertPanel1.TabIndex = 1;
            // 
            // AlertViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1355, 840);
            this.Controls.Add(this.alertPlayerPanel1);
            this.Controls.Add(this.searchAlertPanel1);
            this.Name = "AlertViewForm";
            this.Text = "AlertViewForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlertViewForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private AlertPlayerPanel alertPlayerPanel1;
        private SearchAlertPanel searchAlertPanel1;
    }
}