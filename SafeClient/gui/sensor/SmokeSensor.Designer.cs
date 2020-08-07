namespace gui
{
    partial class SmokeSensor
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // baseSensor1
            // 
            this.baseSensor1.Alarm = false;
            this.baseSensor1.Description = "";
            this.baseSensor1.Location = new System.Drawing.Point(0, 3);
            this.baseSensor1.Max = "maximum";
            this.baseSensor1.Name = "baseSensor1";
            this.baseSensor1.Size = new System.Drawing.Size(650, 130);
            this.baseSensor1.TabIndex = 0;
            this.baseSensor1.Title = "Дым";
            this.baseSensor1.Value = "current";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Properties.Resources.no_fire;
            this.pictureBox1.Location = new System.Drawing.Point(3, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(114, 103);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // SmokeSensor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.baseSensor1);
            this.Name = "SmokeSensor";
            this.Size = new System.Drawing.Size(650, 130);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BaseSensor baseSensor1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
