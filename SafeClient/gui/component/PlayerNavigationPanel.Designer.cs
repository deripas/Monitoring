namespace gui
{
    partial class PlayerNavigationPanel
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
            this.components = new System.ComponentModel.Container();
            this.panelControl = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.playerControlPanel1 = new gui.PlayerControlPanel();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.timerPlayBack = new System.Windows.Forms.Timer(this.components);
            this.panelControl.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl
            // 
            this.panelControl.Controls.Add(this.tableLayoutPanel1);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl.Location = new System.Drawing.Point(0, 0);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(1059, 115);
            this.panelControl.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.playerControlPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.trackBar1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1059, 115);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // playerControlPanel1
            // 
            this.playerControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerControlPanel1.Location = new System.Drawing.Point(3, 37);
            this.playerControlPanel1.Name = "playerControlPanel1";
            this.playerControlPanel1.Size = new System.Drawing.Size(1053, 75);
            this.playerControlPanel1.Sound = false;
            this.playerControlPanel1.TabIndex = 1;
            // 
            // trackBar1
            // 
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar1.Location = new System.Drawing.Point(3, 3);
            this.trackBar1.Maximum = 1000;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(1053, 28);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.TickFrequency = 10;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            this.trackBar1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBar1_MouseDown);
            // 
            // timerPlayBack
            // 
            this.timerPlayBack.Tick += new System.EventHandler(this.timerPlayBack_Tick);
            // 
            // PlayerNavigationPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl);
            this.Name = "PlayerNavigationPanel";
            this.Size = new System.Drawing.Size(1059, 115);
            this.panelControl.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.trackBar1)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelControl;
        private gui.PlayerControlPanel playerControlPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Timer timerPlayBack;
        private System.Windows.Forms.TrackBar trackBar1;

        #endregion
    }
}
