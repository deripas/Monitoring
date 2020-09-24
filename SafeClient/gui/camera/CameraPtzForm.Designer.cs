namespace gui
{
    partial class CameraPtzForm
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
            this.cameraPtzPanel1 = new gui.CameraPtzPanel();
            this.SuspendLayout();
            // 
            // cameraPtzPanel1
            // 
            this.cameraPtzPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cameraPtzPanel1.Location = new System.Drawing.Point(0, 0);
            this.cameraPtzPanel1.Name = "cameraPtzPanel1";
            this.cameraPtzPanel1.Size = new System.Drawing.Size(329, 419);
            this.cameraPtzPanel1.TabIndex = 0;
            // 
            // CameraPtzForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 419);
            this.Controls.Add(this.cameraPtzPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CameraPtzForm";
            this.Text = "CameraPtzForm";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CameraPtzForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private CameraPtzPanel cameraPtzPanel1;
    }
}