namespace gui
{
    partial class BaseSensor
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.name = new System.Windows.Forms.Label();
            this.maximum = new System.Windows.Forms.Label();
            this.current = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.RichTextBox();
            this.led = new System.Windows.Forms.PictureBox();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.led)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.name);
            this.flowLayoutPanel1.Controls.Add(this.maximum);
            this.flowLayoutPanel1.Controls.Add(this.current);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(114, 6);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(413, 36);
            this.flowLayoutPanel1.TabIndex = 15;
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.name.Location = new System.Drawing.Point(6, 0);
            this.name.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(82, 24);
            this.name.TabIndex = 2;
            this.name.Text = "Датчик";
            // 
            // maximum
            // 
            this.maximum.AutoSize = true;
            this.maximum.BackColor = System.Drawing.Color.DarkOrange;
            this.maximum.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maximum.Location = new System.Drawing.Point(100, 0);
            this.maximum.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.maximum.Name = "maximum";
            this.maximum.Size = new System.Drawing.Size(96, 24);
            this.maximum.TabIndex = 8;
            this.maximum.Text = "maximum";
            // 
            // current
            // 
            this.current.AutoSize = true;
            this.current.BackColor = System.Drawing.Color.YellowGreen;
            this.current.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.current.Location = new System.Drawing.Point(208, 0);
            this.current.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.current.Name = "current";
            this.current.Size = new System.Drawing.Size(75, 24);
            this.current.TabIndex = 9;
            this.current.Text = "current";
            // 
            // description
            // 
            this.description.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.description.Location = new System.Drawing.Point(119, 46);
            this.description.Margin = new System.Windows.Forms.Padding(6);
            this.description.Name = "description";
            this.description.ReadOnly = true;
            this.description.Size = new System.Drawing.Size(376, 42);
            this.description.TabIndex = 14;
            this.description.Text = "";
            this.toolTip2.SetToolTip(this.description, "text");
            // 
            // led
            // 
            this.led.Location = new System.Drawing.Point(508, 6);
            this.led.Margin = new System.Windows.Forms.Padding(4);
            this.led.Name = "led";
            this.led.Size = new System.Drawing.Size(61, 54);
            this.led.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.led.TabIndex = 16;
            this.led.TabStop = false;
            this.led.MouseClick += new System.Windows.Forms.MouseEventHandler(this.led_MouseClick);
            // 
            // toolTip2
            // 
            this.toolTip2.IsBalloon = true;
            // 
            // BaseSensor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.led);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.description);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BaseSensor";
            this.Size = new System.Drawing.Size(594, 92);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.led)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label current;
        private System.Windows.Forms.RichTextBox description;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox led;
        private System.Windows.Forms.Label maximum;
        private System.Windows.Forms.Label name;

        #endregion

        private System.Windows.Forms.ToolTip toolTip2;
    }
}
