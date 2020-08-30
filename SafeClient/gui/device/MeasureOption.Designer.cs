namespace gui
{
    partial class MeasureOption
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.thresholdMinText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.maxText = new System.Windows.Forms.TextBox();
            this.minText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.thresholdMaxText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.thresholdMaxText);
            this.groupBox2.Controls.Add(this.thresholdMinText);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.maxText);
            this.groupBox2.Controls.Add(this.minText);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(0, 6);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox2.Size = new System.Drawing.Size(422, 224);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Калибровка";
            // 
            // thresholdMinText
            // 
            this.thresholdMinText.Location = new System.Drawing.Point(183, 170);
            this.thresholdMinText.Margin = new System.Windows.Forms.Padding(6);
            this.thresholdMinText.Name = "thresholdMinText";
            this.thresholdMinText.Size = new System.Drawing.Size(211, 29);
            this.thresholdMinText.TabIndex = 43;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(55, 39);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 25);
            this.label7.TabIndex = 38;
            this.label7.Text = "Макс.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 129);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 25);
            this.label1.TabIndex = 42;
            this.label1.Text = "Порог Макс.";
            // 
            // maxText
            // 
            this.maxText.Location = new System.Drawing.Point(183, 33);
            this.maxText.Margin = new System.Windows.Forms.Padding(6);
            this.maxText.Name = "maxText";
            this.maxText.Size = new System.Drawing.Size(211, 29);
            this.maxText.TabIndex = 39;
            // 
            // minText
            // 
            this.minText.Location = new System.Drawing.Point(183, 81);
            this.minText.Margin = new System.Windows.Forms.Padding(6);
            this.minText.Name = "minText";
            this.minText.Size = new System.Drawing.Size(211, 29);
            this.minText.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(55, 87);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 25);
            this.label6.TabIndex = 40;
            this.label6.Text = "Мин.";
            // 
            // thresholdMaxText
            // 
            this.thresholdMaxText.Location = new System.Drawing.Point(183, 129);
            this.thresholdMaxText.Margin = new System.Windows.Forms.Padding(6);
            this.thresholdMaxText.Name = "thresholdMaxText";
            this.thresholdMaxText.Size = new System.Drawing.Size(211, 29);
            this.thresholdMaxText.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 170);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 25);
            this.label2.TabIndex = 45;
            this.label2.Text = "Порог Мин.";
            // 
            // MeasureOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Name = "MeasureOption";
            this.Size = new System.Drawing.Size(428, 239);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox thresholdMinText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox maxText;
        private System.Windows.Forms.TextBox minText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox thresholdMaxText;
    }
}
