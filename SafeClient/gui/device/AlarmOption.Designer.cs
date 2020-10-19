namespace gui
{
    partial class AlarmOption
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.timeoutText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.periodText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.countText = new System.Windows.Forms.TextBox();
            this.delayText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.timeoutText);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.periodText);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.countText);
            this.groupBox2.Controls.Add(this.delayText);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(7, 6);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox2.Size = new System.Drawing.Size(460, 252);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Оповещение";
            // 
            // timeoutText
            // 
            this.timeoutText.Location = new System.Drawing.Point(199, 36);
            this.timeoutText.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.timeoutText.Name = "timeoutText";
            this.timeoutText.Size = new System.Drawing.Size(230, 31);
            this.timeoutText.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 25);
            this.label1.TabIndex = 29;
            this.label1.Text = "Таймаут (с)";
            // 
            // periodText
            // 
            this.periodText.Location = new System.Drawing.Point(199, 186);
            this.periodText.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.periodText.Name = "periodText";
            this.periodText.Size = new System.Drawing.Size(230, 31);
            this.periodText.TabIndex = 36;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(58, 89);
            this.label8.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 25);
            this.label8.TabIndex = 31;
            this.label8.Text = "Количество";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(59, 189);
            this.label6.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 25);
            this.label6.TabIndex = 35;
            this.label6.Text = "Период (с)";
            // 
            // countText
            // 
            this.countText.Location = new System.Drawing.Point(199, 86);
            this.countText.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.countText.Name = "countText";
            this.countText.Size = new System.Drawing.Size(230, 31);
            this.countText.TabIndex = 32;
            // 
            // delayText
            // 
            this.delayText.Location = new System.Drawing.Point(199, 136);
            this.delayText.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.delayText.Name = "delayText";
            this.delayText.Size = new System.Drawing.Size(230, 31);
            this.delayText.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(58, 139);
            this.label7.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 25);
            this.label7.TabIndex = 33;
            this.label7.Text = "Задержка (с)";
            // 
            // AlarmOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Name = "AlarmOption";
            this.Size = new System.Drawing.Size(485, 268);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TextBox countText;
        private System.Windows.Forms.TextBox delayText;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox periodText;
        private System.Windows.Forms.TextBox timeoutText;

        #endregion
    }
}
