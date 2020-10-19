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
            this.label2 = new System.Windows.Forms.Label();
            this.thresholdMaxText = new System.Windows.Forms.TextBox();
            this.thresholdMinText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.maxText = new System.Windows.Forms.TextBox();
            this.minText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.maxText);
            this.groupBox2.Controls.Add(this.minText);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(7, 6);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox2.Size = new System.Drawing.Size(460, 132);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Калибровка";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 25);
            this.label2.TabIndex = 45;
            this.label2.Text = "Порог Мин.";
            // 
            // thresholdMaxText
            // 
            this.thresholdMaxText.Location = new System.Drawing.Point(193, 36);
            this.thresholdMaxText.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.thresholdMaxText.Name = "thresholdMaxText";
            this.thresholdMaxText.Size = new System.Drawing.Size(246, 31);
            this.thresholdMaxText.TabIndex = 44;
            // 
            // thresholdMinText
            // 
            this.thresholdMinText.Location = new System.Drawing.Point(193, 79);
            this.thresholdMinText.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.thresholdMinText.Name = "thresholdMinText";
            this.thresholdMinText.Size = new System.Drawing.Size(246, 31);
            this.thresholdMinText.TabIndex = 43;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(60, 41);
            this.label7.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 25);
            this.label7.TabIndex = 38;
            this.label7.Text = "Макс.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 25);
            this.label1.TabIndex = 42;
            this.label1.Text = "Порог Макс.";
            // 
            // maxText
            // 
            this.maxText.Location = new System.Drawing.Point(200, 34);
            this.maxText.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.maxText.Name = "maxText";
            this.maxText.Size = new System.Drawing.Size(246, 31);
            this.maxText.TabIndex = 39;
            // 
            // minText
            // 
            this.minText.Location = new System.Drawing.Point(200, 84);
            this.minText.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.minText.Name = "minText";
            this.minText.Size = new System.Drawing.Size(246, 31);
            this.minText.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 91);
            this.label6.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 25);
            this.label6.TabIndex = 40;
            this.label6.Text = "Мин.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.thresholdMaxText);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.thresholdMinText);
            this.groupBox1.Location = new System.Drawing.Point(7, 150);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox1.Size = new System.Drawing.Size(460, 124);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тревога";
            // 
            // MeasureOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "MeasureOption";
            this.Size = new System.Drawing.Size(485, 284);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
