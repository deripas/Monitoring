namespace gui
{
    partial class TemperatureSensor
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
            this.baseSensor1 = new gui.BaseSensor();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.verticalProgressBar1 = new gui.component.VerticalProgressBar();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // baseSensor1
            // 
            this.baseSensor1.Alarm = false;
            this.baseSensor1.Description = "";
            this.baseSensor1.Location = new System.Drawing.Point(0, 0);
            this.baseSensor1.Max = "maximum";
            this.baseSensor1.Name = "baseSensor1";
            this.baseSensor1.Size = new System.Drawing.Size(576, 112);
            this.baseSensor1.TabIndex = 0;
            this.baseSensor1.Title = "Температура";
            this.baseSensor1.Value = "current";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Properties.Resources.temperature;
            this.pictureBox1.Location = new System.Drawing.Point(20, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(73, 108);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // verticalProgressBar1
            // 
            this.verticalProgressBar1.ForeColor = System.Drawing.Color.Red;
            this.verticalProgressBar1.Location = new System.Drawing.Point(51, 15);
            this.verticalProgressBar1.Name = "verticalProgressBar1";
            this.verticalProgressBar1.Size = new System.Drawing.Size(10, 91);
            this.verticalProgressBar1.TabIndex = 2;
            this.verticalProgressBar1.Value = 50;
            // 
            // TemperatureSensor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.verticalProgressBar1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.baseSensor1);
            this.Name = "TemperatureSensor";
            this.Size = new System.Drawing.Size(578, 114);
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
        }

        private gui.BaseSensor baseSensor1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private gui.component.VerticalProgressBar verticalProgressBar1;

        #endregion
    }
}
