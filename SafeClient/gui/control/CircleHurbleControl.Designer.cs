namespace gui
{
    partial class CircleHurbleControl
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
            this.checkBoxEnable = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.name = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.RichTextBox();
            this.pictureIcon = new System.Windows.Forms.PictureBox();
            this.led = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxEnable
            // 
            this.checkBoxEnable.AutoSize = true;
            this.checkBoxEnable.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxEnable.Location = new System.Drawing.Point(600, 70);
            this.checkBoxEnable.Name = "checkBoxEnable";
            this.checkBoxEnable.Size = new System.Drawing.Size(82, 43);
            this.checkBoxEnable.TabIndex = 33;
            this.checkBoxEnable.Text = "💤";
            this.checkBoxEnable.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.name);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(132, 9);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(356, 35);
            this.flowLayoutPanel1.TabIndex = 30;
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.name.Location = new System.Drawing.Point(6, 0);
            this.name.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(159, 32);
            this.name.TabIndex = 2;
            this.name.Text = "Оптоствор";
            // 
            // description
            // 
            this.description.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.description.Location = new System.Drawing.Point(132, 47);
            this.description.Margin = new System.Windows.Forms.Padding(6);
            this.description.Name = "description";
            this.description.ReadOnly = true;
            this.description.Size = new System.Drawing.Size(356, 73);
            this.description.TabIndex = 29;
            this.description.Text = "";
            // 
            // pictureIcon
            // 
            this.pictureIcon.Image = global::Properties.Resources.circle_close;
            this.pictureIcon.Location = new System.Drawing.Point(7, 3);
            this.pictureIcon.Name = "pictureIcon";
            this.pictureIcon.Size = new System.Drawing.Size(116, 124);
            this.pictureIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureIcon.TabIndex = 32;
            this.pictureIcon.TabStop = false;
            // 
            // led
            // 
            this.led.Image = global::Properties.Resources.led_green;
            this.led.Location = new System.Drawing.Point(600, 5);
            this.led.Name = "led";
            this.led.Size = new System.Drawing.Size(69, 59);
            this.led.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.led.TabIndex = 31;
            this.led.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(513, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 61);
            this.button1.TabIndex = 34;
            this.button1.Text = "🔐";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // CircleHurbleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBoxEnable);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pictureIcon);
            this.Controls.Add(this.led);
            this.Controls.Add(this.description);
            this.Name = "CircleHurbleControl";
            this.Size = new System.Drawing.Size(699, 150);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxEnable;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.PictureBox pictureIcon;
        private System.Windows.Forms.PictureBox led;
        private System.Windows.Forms.RichTextBox description;
        private System.Windows.Forms.Button button1;
    }
}
