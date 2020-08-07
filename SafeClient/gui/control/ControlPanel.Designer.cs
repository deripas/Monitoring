namespace gui
{
    partial class ControlPanel
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.rolletControl1 = new gui.RolletControl();
            this.circleHurbleControl1 = new gui.CircleHurbleControl();
            this.classicHurbleControl1 = new gui.ClassicHurbleControl();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.rolletControl1);
            this.flowLayoutPanel1.Controls.Add(this.circleHurbleControl1);
            this.flowLayoutPanel1.Controls.Add(this.classicHurbleControl1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(2180, 167);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // rolletControl1
            // 
            this.rolletControl1.Location = new System.Drawing.Point(3, 3);
            this.rolletControl1.Name = "rolletControl1";
            this.rolletControl1.Size = new System.Drawing.Size(729, 134);
            this.rolletControl1.TabIndex = 0;
            // 
            // circleHurbleControl1
            // 
            this.circleHurbleControl1.Location = new System.Drawing.Point(738, 3);
            this.circleHurbleControl1.Name = "circleHurbleControl1";
            this.circleHurbleControl1.Size = new System.Drawing.Size(699, 150);
            this.circleHurbleControl1.TabIndex = 1;
            // 
            // classicHurbleControl1
            // 
            this.classicHurbleControl1.Location = new System.Drawing.Point(1443, 3);
            this.classicHurbleControl1.Name = "classicHurbleControl1";
            this.classicHurbleControl1.Size = new System.Drawing.Size(734, 161);
            this.classicHurbleControl1.TabIndex = 2;
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ControlPanel";
            this.Size = new System.Drawing.Size(843, 170);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private RolletControl rolletControl1;
        private CircleHurbleControl circleHurbleControl1;
        private ClassicHurbleControl classicHurbleControl1;
    }
}
