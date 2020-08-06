namespace gui
{
    partial class VideoExportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dateTimeFromDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimeToDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimeFromTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimeToTime = new System.Windows.Forms.DateTimePicker();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimeFromDate
            // 
            this.dateTimeFromDate.CustomFormat = "dd.MM.yyyy";
            this.dateTimeFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeFromDate.Location = new System.Drawing.Point(12, 12);
            this.dateTimeFromDate.Name = "dateTimeFromDate";
            this.dateTimeFromDate.Size = new System.Drawing.Size(200, 29);
            this.dateTimeFromDate.TabIndex = 0;
            // 
            // dateTimeToDate
            // 
            this.dateTimeToDate.CustomFormat = "dd.MM.yyyy";
            this.dateTimeToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeToDate.Location = new System.Drawing.Point(12, 62);
            this.dateTimeToDate.Name = "dateTimeToDate";
            this.dateTimeToDate.Size = new System.Drawing.Size(200, 29);
            this.dateTimeToDate.TabIndex = 1;
            // 
            // dateTimeFromTime
            // 
            this.dateTimeFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimeFromTime.Location = new System.Drawing.Point(229, 12);
            this.dateTimeFromTime.Name = "dateTimeFromTime";
            this.dateTimeFromTime.ShowUpDown = true;
            this.dateTimeFromTime.Size = new System.Drawing.Size(200, 29);
            this.dateTimeFromTime.TabIndex = 2;
            // 
            // dateTimeToTime
            // 
            this.dateTimeToTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimeToTime.Location = new System.Drawing.Point(229, 62);
            this.dateTimeToTime.Name = "dateTimeToTime";
            this.dateTimeToTime.ShowUpDown = true;
            this.dateTimeToTime.Size = new System.Drawing.Size(200, 29);
            this.dateTimeToTime.TabIndex = 3;
            // 
            // buttonSelect
            // 
            this.buttonSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSelect.Location = new System.Drawing.Point(451, 14);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(91, 77);
            this.buttonSelect.TabIndex = 5;
            this.buttonSelect.Text = "💾";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 113);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(532, 27);
            this.progressBar1.TabIndex = 6;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 153);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(560, 39);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(100, 30);
            this.toolStripStatusLabel1.Text = "select file";
            // 
            // VideoExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 192);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.dateTimeToTime);
            this.Controls.Add(this.dateTimeFromTime);
            this.Controls.Add(this.dateTimeToDate);
            this.Controls.Add(this.dateTimeFromDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "VideoExportForm";
            this.Text = "VideoExportForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VideoExportForm_FormClosed);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimeFromDate;
        private System.Windows.Forms.DateTimePicker dateTimeToDate;
        private System.Windows.Forms.DateTimePicker dateTimeFromTime;
        private System.Windows.Forms.DateTimePicker dateTimeToTime;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}