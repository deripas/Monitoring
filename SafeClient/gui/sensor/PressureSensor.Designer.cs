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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.baseSensor1 = new gui.BaseSensor();
            this.verticalProgressBar1 = new gui.component.VerticalProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // baseSensor1
            // 
            this.baseSensor1.Alarm = false;
            this.baseSensor1.Description = "";
            this.baseSensor1.Device = null;
            this.baseSensor1.EnabledLed = true;
            this.baseSensor1.Location = new System.Drawing.Point(0, 0);
            this.baseSensor1.Margin = new System.Windows.Forms.Padding(2);
            this.baseSensor1.Max = "maximum";
            this.baseSensor1.Name = "baseSensor1";
            this.baseSensor1.Size = new System.Drawing.Size(628, 117);
            this.baseSensor1.TabIndex = 0;
            this.baseSensor1.Title = "Давление";
            this.baseSensor1.Value = "current";
            // 
            // verticalProgressBar1
            // 
            this.verticalProgressBar1.ForeColor = System.Drawing.Color.Blue;
            this.verticalProgressBar1.Location = new System.Drawing.Point(82, 4);
            this.verticalProgressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.verticalProgressBar1.Name = "verticalProgressBar1";
            this.verticalProgressBar1.Size = new System.Drawing.Size(38, 94);
            this.verticalProgressBar1.TabIndex = 2;
            this.verticalProgressBar1.Value = 50;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Properties.Resources.hygrometer_icon;
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(66, 85);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            // 
            // PressureSensor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.verticalProgressBar1);
            this.Controls.Add(this.baseSensor1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PressureSensor";
            this.Size = new System.Drawing.Size(630, 96);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private gui.BaseSensor baseSensor1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private gui.component.VerticalProgressBar verticalProgressBar1;

        #endregion
    }
}
