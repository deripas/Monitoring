﻿namespace gui
{
    partial class VideoPlayerPanel
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.canvasPanel1 = new gui.CanvasPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.speedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.playerNavigationPanel1 = new gui.PlayerNavigationPanel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // canvasPanel1
            // 
            this.canvasPanel1.BackColor = System.Drawing.Color.Black;
            this.canvasPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvasPanel1.Location = new System.Drawing.Point(0, 0);
            this.canvasPanel1.Name = "canvasPanel1";
            this.canvasPanel1.Ratio = 0.75D;
            this.canvasPanel1.Selected = false;
            this.canvasPanel1.Size = new System.Drawing.Size(1337, 599);
            this.canvasPanel1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.speedLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 735);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 15, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1337, 42);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // speedLabel
            // 
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(196, 32);
            this.speedLabel.Text = "Файл не выбран";
            // 
            // playerNavigationPanel1
            // 
            this.playerNavigationPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.playerNavigationPanel1.Location = new System.Drawing.Point(0, 599);
            this.playerNavigationPanel1.Name = "playerNavigationPanel1";
            this.playerNavigationPanel1.Size = new System.Drawing.Size(1337, 136);
            this.playerNavigationPanel1.TabIndex = 3;
            this.playerNavigationPanel1.VideoPlayer = null;
            this.playerNavigationPanel1.VisibleTrackBar = true;
            // 
            // VideoPlayerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.canvasPanel1);
            this.Controls.Add(this.playerNavigationPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "VideoPlayerPanel";
            this.Size = new System.Drawing.Size(1337, 777);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private gui.CanvasPanel canvasPanel1;
        private gui.PlayerNavigationPanel playerNavigationPanel1;
        private System.Windows.Forms.ToolStripStatusLabel speedLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;

        #endregion
    }
}
