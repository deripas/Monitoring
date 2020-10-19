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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cameraComboBox = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.videoFileList1 = new gui.VideoFileList();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cameraComboBox
            // 
            this.cameraComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cameraComboBox.FormattingEnabled = true;
            this.cameraComboBox.Location = new System.Drawing.Point(4, 50);
            this.cameraComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cameraComboBox.Name = "cameraComboBox";
            this.cameraComboBox.Size = new System.Drawing.Size(376, 33);
            this.cameraComboBox.TabIndex = 12;
            this.cameraComboBox.SelectedIndexChanged += new System.EventHandler(this.cameraComboBox_SelectedIndexChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(4, 4);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(376, 31);
            this.dateTimePicker1.TabIndex = 11;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cameraComboBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.videoFileList1, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(384, 658);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // videoFileList1
            // 
            this.videoFileList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoFileList1.Location = new System.Drawing.Point(2, 94);
            this.videoFileList1.Margin = new System.Windows.Forms.Padding(2);
            this.videoFileList1.Name = "videoFileList1";
            this.videoFileList1.Size = new System.Drawing.Size(380, 562);
            this.videoFileList1.TabIndex = 18;
            // 
            // SearchVideoFileHistoryPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SearchVideoFileHistoryPanel";
            this.Size = new System.Drawing.Size(384, 658);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.ComboBox cameraComboBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private gui.VideoFileList videoFileList1;

        #endregion
    }
}
