namespace gui
{
    partial class SensorPanel
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
            this.temperatureSensor2 = new gui.TemperatureSensor();
            this.pressureSensor1 = new gui.PressureSensor();
            this.leakSensor1 = new gui.LeakSensor();
            this.smokeSensor1 = new gui.SmokeSensor();
            this.vibrationSensor1 = new gui.VibrationSensor();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.temperatureSensor2);
            this.flowLayoutPanel1.Controls.Add(this.pressureSensor1);
            this.flowLayoutPanel1.Controls.Add(this.leakSensor1);
            this.flowLayoutPanel1.Controls.Add(this.smokeSensor1);
            this.flowLayoutPanel1.Controls.Add(this.vibrationSensor1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(582, 2000);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // temperatureSensor2
            // 
            this.temperatureSensor2.Location = new System.Drawing.Point(3, 3);
            this.temperatureSensor2.Name = "temperatureSensor2";
            this.temperatureSensor2.Size = new System.Drawing.Size(650, 130);
            this.temperatureSensor2.TabIndex = 1;
            // 
            // pressureSensor1
            // 
            this.pressureSensor1.Location = new System.Drawing.Point(3, 139);
            this.pressureSensor1.Name = "pressureSensor1";
            this.pressureSensor1.Size = new System.Drawing.Size(650, 130);
            this.pressureSensor1.TabIndex = 2;
            // 
            // leakSensor1
            // 
            this.leakSensor1.Location = new System.Drawing.Point(3, 275);
            this.leakSensor1.Name = "leakSensor1";
            this.leakSensor1.Size = new System.Drawing.Size(650, 130);
            this.leakSensor1.TabIndex = 3;
            // 
            // smokeSensor1
            // 
            this.smokeSensor1.Location = new System.Drawing.Point(3, 411);
            this.smokeSensor1.Name = "smokeSensor1";
            this.smokeSensor1.Size = new System.Drawing.Size(650, 130);
            this.smokeSensor1.TabIndex = 4;
            // 
            // vibrationSensor1
            // 
            this.vibrationSensor1.Location = new System.Drawing.Point(3, 547);
            this.vibrationSensor1.Name = "vibrationSensor1";
            this.vibrationSensor1.Size = new System.Drawing.Size(650, 130);
            this.vibrationSensor1.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(3, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 2000);
            this.panel1.TabIndex = 3;
            // 
            // SensorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.panel1);
            this.Name = "SensorPanel";
            this.Size = new System.Drawing.Size(590, 700);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private TemperatureSensor temperatureSensor2;
        private PressureSensor pressureSensor1;
        private LeakSensor leakSensor1;
        private SmokeSensor smokeSensor1;
        private VibrationSensor vibrationSensor1;
        private System.Windows.Forms.Panel panel1;
    }
}
