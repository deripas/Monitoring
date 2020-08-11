namespace gui
{
    partial class PressureSensor
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
            this.baseSensor1 = new gui.BaseSensor();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.verticalProgressBar1 = new gui.component.VerticalProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // baseSensor1
            // 
            this.baseSensor1.Alarm = false;
            this.baseSensor1.Description = "";
            this.baseSensor1.Location = new System.Drawing.Point(3, 3);
            this.baseSensor1.Max = "maximum";
            this.baseSensor1.Name = "baseSensor1";
            this.baseSensor1.Size = new System.Drawing.Size(576, 112);
            this.baseSensor1.TabIndex = 0;
            this.baseSensor1.Title = "Давление";
            this.baseSensor1.Value = "current";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Properties.Resources.bar;
            this.pictureBox1.Location = new System.Drawing.Point(29, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(68, 119);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // verticalProgressBar1
            // 
            this.verticalProgressBar1.ForeColor = System.Drawing.Color.Blue;
            this.verticalProgressBar1.Location = new System.Drawing.Point(58, 13);
            this.verticalProgressBar1.Name = "verticalProgressBar1";
            this.verticalProgressBar1.Size = new System.Drawing.Size(26, 90);
            this.verticalProgressBar1.TabIndex = 2;
            this.verticalProgressBar1.Value = 50;
            // 
            // PressureSensor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.verticalProgressBar1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.baseSensor1);
            this.Name = "PressureSensor";
            this.Size = new System.Drawing.Size(578, 114);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BaseSensor baseSensor1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private component.VerticalProgressBar verticalProgressBar1;
    }
}
