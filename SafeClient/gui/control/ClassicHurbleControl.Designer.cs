namespace gui
{
    partial class ClassicHurbleControl
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
            this.name = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.RichTextBox();
            this.pictureIcon = new System.Windows.Forms.PictureBox();
            this.led = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.modeOff = new System.Windows.Forms.RadioButton();
            this.modeoOn = new System.Windows.Forms.RadioButton();
            this.modeAuto = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.name);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(157, 6);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(238, 35);
            this.flowLayoutPanel1.TabIndex = 25;
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.name.Location = new System.Drawing.Point(6, 0);
            this.name.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(121, 24);
            this.name.TabIndex = 2;
            this.name.Text = "Оптоствор";
            // 
            // description
            // 
            this.description.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.description.Location = new System.Drawing.Point(157, 44);
            this.description.Margin = new System.Windows.Forms.Padding(6);
            this.description.Name = "description";
            this.description.ReadOnly = true;
            this.description.Size = new System.Drawing.Size(226, 82);
            this.description.TabIndex = 24;
            this.description.Text = "";
            // 
            // pictureIcon
            // 
            this.pictureIcon.Image = global::Properties.Resources.classic_close;
            this.pictureIcon.Location = new System.Drawing.Point(15, 31);
            this.pictureIcon.Name = "pictureIcon";
            this.pictureIcon.Size = new System.Drawing.Size(133, 92);
            this.pictureIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureIcon.TabIndex = 27;
            this.pictureIcon.TabStop = false;
            // 
            // led
            // 
            this.led.Image = global::Properties.Resources.led_green;
            this.led.Location = new System.Drawing.Point(635, 46);
            this.led.Name = "led";
            this.led.Size = new System.Drawing.Size(69, 59);
            this.led.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.led.TabIndex = 26;
            this.led.TabStop = false;
            this.led.MouseClick += new System.Windows.Forms.MouseEventHandler(this.led_MouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel2);
            this.groupBox1.Location = new System.Drawing.Point(392, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 116);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Режим";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.modeOff);
            this.flowLayoutPanel2.Controls.Add(this.modeoOn);
            this.flowLayoutPanel2.Controls.Add(this.modeAuto);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 25);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(222, 88);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // modeOff
            // 
            this.modeOff.AutoSize = true;
            this.modeOff.Location = new System.Drawing.Point(3, 3);
            this.modeOff.Name = "modeOff";
            this.modeOff.Size = new System.Drawing.Size(79, 24);
            this.modeOff.TabIndex = 0;
            this.modeOff.TabStop = true;
            this.modeOff.Text = "выкл.";
            this.modeOff.UseVisualStyleBackColor = true;
            this.modeOff.Click += new System.EventHandler(this.modeOff_Click);
            // 
            // modeoOn
            // 
            this.modeoOn.AutoSize = true;
            this.modeoOn.Location = new System.Drawing.Point(3, 33);
            this.modeoOn.Name = "modeoOn";
            this.modeoOn.Size = new System.Drawing.Size(67, 24);
            this.modeoOn.TabIndex = 1;
            this.modeoOn.TabStop = true;
            this.modeoOn.Text = "вкл.";
            this.modeoOn.UseVisualStyleBackColor = true;
            this.modeoOn.Click += new System.EventHandler(this.modeoOn_Click);
            // 
            // modeAuto
            // 
            this.modeAuto.AutoSize = true;
            this.modeAuto.Location = new System.Drawing.Point(88, 3);
            this.modeAuto.Name = "modeAuto";
            this.modeAuto.Size = new System.Drawing.Size(74, 24);
            this.modeAuto.TabIndex = 2;
            this.modeAuto.TabStop = true;
            this.modeAuto.Text = "авто";
            this.modeAuto.UseVisualStyleBackColor = true;
            this.modeAuto.Click += new System.EventHandler(this.modeAuto_Click);
            // 
            // ClassicHurbleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pictureIcon);
            this.Controls.Add(this.led);
            this.Controls.Add(this.description);
            this.Name = "ClassicHurbleControl";
            this.Size = new System.Drawing.Size(719, 132);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.PictureBox pictureIcon;
        private System.Windows.Forms.PictureBox led;
        private System.Windows.Forms.RichTextBox description;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.RadioButton modeOff;
        private System.Windows.Forms.RadioButton modeoOn;
        private System.Windows.Forms.RadioButton modeAuto;
    }
}
