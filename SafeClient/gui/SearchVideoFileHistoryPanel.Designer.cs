namespace gui
{
    partial class SearchVideoFileHistoryPanel
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
            this.alarmCheckBox = new System.Windows.Forms.CheckBox();
            this.regularCheckBox = new System.Windows.Forms.CheckBox();
            this.detectCheckBox = new System.Windows.Forms.CheckBox();
            this.manualCheckBox = new System.Windows.Forms.CheckBox();
            this.findButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.cameraComboBox = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // alarmCheckBox
            // 
            this.alarmCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.alarmCheckBox.AutoSize = true;
            this.alarmCheckBox.Checked = true;
            this.alarmCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.alarmCheckBox.Location = new System.Drawing.Point(3, 8);
            this.alarmCheckBox.Name = "alarmCheckBox";
            this.alarmCheckBox.Size = new System.Drawing.Size(52, 29);
            this.alarmCheckBox.TabIndex = 0;
            this.alarmCheckBox.Text = "A";
            this.alarmCheckBox.UseVisualStyleBackColor = true;
            // 
            // regularCheckBox
            // 
            this.regularCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.regularCheckBox.AutoSize = true;
            this.regularCheckBox.Checked = true;
            this.regularCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.regularCheckBox.Location = new System.Drawing.Point(61, 8);
            this.regularCheckBox.Name = "regularCheckBox";
            this.regularCheckBox.Size = new System.Drawing.Size(51, 29);
            this.regularCheckBox.TabIndex = 1;
            this.regularCheckBox.Text = "R";
            this.regularCheckBox.UseVisualStyleBackColor = true;
            // 
            // detectCheckBox
            // 
            this.detectCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.detectCheckBox.AutoSize = true;
            this.detectCheckBox.Checked = true;
            this.detectCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.detectCheckBox.Location = new System.Drawing.Point(118, 8);
            this.detectCheckBox.Name = "detectCheckBox";
            this.detectCheckBox.Size = new System.Drawing.Size(52, 29);
            this.detectCheckBox.TabIndex = 2;
            this.detectCheckBox.Text = "D";
            this.detectCheckBox.UseVisualStyleBackColor = true;
            // 
            // manualCheckBox
            // 
            this.manualCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.manualCheckBox.AutoSize = true;
            this.manualCheckBox.Checked = true;
            this.manualCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.manualCheckBox.Location = new System.Drawing.Point(176, 8);
            this.manualCheckBox.Name = "manualCheckBox";
            this.manualCheckBox.Size = new System.Drawing.Size(55, 29);
            this.manualCheckBox.TabIndex = 3;
            this.manualCheckBox.Text = "M";
            this.manualCheckBox.UseVisualStyleBackColor = true;
            // 
            // findButton
            // 
            this.findButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.findButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.findButton.Location = new System.Drawing.Point(237, 3);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(106, 39);
            this.findButton.TabIndex = 14;
            this.findButton.Text = "🔎";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 24;
            this.listBox1.Location = new System.Drawing.Point(3, 143);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(346, 486);
            this.listBox1.TabIndex = 13;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // cameraComboBox
            // 
            this.cameraComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cameraComboBox.FormattingEnabled = true;
            this.cameraComboBox.Location = new System.Drawing.Point(3, 48);
            this.cameraComboBox.Name = "cameraComboBox";
            this.cameraComboBox.Size = new System.Drawing.Size(346, 32);
            this.cameraComboBox.TabIndex = 12;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(3, 3);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(346, 29);
            this.dateTimePicker1.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.listBox1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cameraComboBox, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(352, 632);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.findButton, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.manualCheckBox, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.detectCheckBox, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.regularCheckBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.alarmCheckBox, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 93);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(346, 44);
            this.tableLayoutPanel2.TabIndex = 17;
            // 
            // SearchVideoFileHistoryPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SearchVideoFileHistoryPanel";
            this.Size = new System.Drawing.Size(352, 632);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox alarmCheckBox;
        private System.Windows.Forms.CheckBox regularCheckBox;
        private System.Windows.Forms.CheckBox detectCheckBox;
        private System.Windows.Forms.CheckBox manualCheckBox;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox cameraComboBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}
