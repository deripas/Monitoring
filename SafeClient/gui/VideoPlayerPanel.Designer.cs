namespace gui
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
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
            this.canvasPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvasPanel1.Location = new System.Drawing.Point(0, 0);
            this.canvasPanel1.Name = "canvasPanel1";
            this.canvasPanel1.Ratio = 0.75D;
            this.canvasPanel1.Selected = false;
            this.canvasPanel1.Size = new System.Drawing.Size(1226, 592);
            this.canvasPanel1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.speedLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 707);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1226, 39);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // speedLabel
            // 
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(170, 30);
            this.speedLabel.Text = "Файл не выбран";
            // 
            // playerNavigationPanel1
            // 
            this.playerNavigationPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.playerNavigationPanel1.Location = new System.Drawing.Point(0, 592);
            this.playerNavigationPanel1.Name = "playerNavigationPanel1";
            this.playerNavigationPanel1.Size = new System.Drawing.Size(1226, 115);
            this.playerNavigationPanel1.TabIndex = 3;
            this.playerNavigationPanel1.VideoPlayer = null;
            // 
            // VideoPlayerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.canvasPanel1);
            this.Controls.Add(this.playerNavigationPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "VideoPlayerPanel";
            this.Size = new System.Drawing.Size(1226, 746);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CanvasPanel canvasPanel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel speedLabel;
        private PlayerNavigationPanel playerNavigationPanel1;
    }
}
