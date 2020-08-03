namespace gui
{
    partial class VideoViewForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.alarmCheckBox = new System.Windows.Forms.CheckBox();
            this.regularCheckBox = new System.Windows.Forms.CheckBox();
            this.detectCheckBox = new System.Windows.Forms.CheckBox();
            this.manualCheckBox = new System.Windows.Forms.CheckBox();
            this.findButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.cameraComboBox = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.videoPlayerPanel1 = new gui.VideoPlayerPanel();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.findButton);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.cameraComboBox);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(411, 684);
            this.panel1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.alarmCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.regularCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.detectCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.manualCheckBox);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 121);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(275, 52);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // alarmCheckBox
            // 
            this.alarmCheckBox.AutoSize = true;
            this.alarmCheckBox.Checked = true;
            this.alarmCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.alarmCheckBox.Location = new System.Drawing.Point(3, 3);
            this.alarmCheckBox.Name = "alarmCheckBox";
            this.alarmCheckBox.Size = new System.Drawing.Size(52, 29);
            this.alarmCheckBox.TabIndex = 0;
            this.alarmCheckBox.Text = "A";
            this.alarmCheckBox.UseVisualStyleBackColor = true;
            // 
            // regularCheckBox
            // 
            this.regularCheckBox.AutoSize = true;
            this.regularCheckBox.Checked = true;
            this.regularCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.regularCheckBox.Location = new System.Drawing.Point(61, 3);
            this.regularCheckBox.Name = "regularCheckBox";
            this.regularCheckBox.Size = new System.Drawing.Size(51, 29);
            this.regularCheckBox.TabIndex = 1;
            this.regularCheckBox.Text = "R";
            this.regularCheckBox.UseVisualStyleBackColor = true;
            // 
            // detectCheckBox
            // 
            this.detectCheckBox.AutoSize = true;
            this.detectCheckBox.Checked = true;
            this.detectCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.detectCheckBox.Location = new System.Drawing.Point(118, 3);
            this.detectCheckBox.Name = "detectCheckBox";
            this.detectCheckBox.Size = new System.Drawing.Size(52, 29);
            this.detectCheckBox.TabIndex = 2;
            this.detectCheckBox.Text = "D";
            this.detectCheckBox.UseVisualStyleBackColor = true;
            // 
            // manualCheckBox
            // 
            this.manualCheckBox.AutoSize = true;
            this.manualCheckBox.Checked = true;
            this.manualCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.manualCheckBox.Location = new System.Drawing.Point(176, 3);
            this.manualCheckBox.Name = "manualCheckBox";
            this.manualCheckBox.Size = new System.Drawing.Size(55, 29);
            this.manualCheckBox.TabIndex = 3;
            this.manualCheckBox.Text = "M";
            this.manualCheckBox.UseVisualStyleBackColor = true;
            // 
            // findButton
            // 
            this.findButton.Location = new System.Drawing.Point(293, 121);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(81, 36);
            this.findButton.TabIndex = 9;
            this.findButton.Text = "find";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 24;
            this.listBox1.Location = new System.Drawing.Point(22, 207);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(313, 436);
            this.listBox1.TabIndex = 8;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // cameraComboBox
            // 
            this.cameraComboBox.FormattingEnabled = true;
            this.cameraComboBox.Location = new System.Drawing.Point(16, 67);
            this.cameraComboBox.Name = "cameraComboBox";
            this.cameraComboBox.Size = new System.Drawing.Size(300, 32);
            this.cameraComboBox.TabIndex = 7;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(16, 21);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(300, 29);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // videoPlayerPanel1
            // 
            this.videoPlayerPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoPlayerPanel1.Location = new System.Drawing.Point(411, 0);
            this.videoPlayerPanel1.Name = "videoPlayerPanel1";
            this.videoPlayerPanel1.Ratio = 0.75D;
            this.videoPlayerPanel1.Size = new System.Drawing.Size(997, 684);
            this.videoPlayerPanel1.TabIndex = 0;
            // 
            // VideoViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1408, 684);
            this.Controls.Add(this.videoPlayerPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "VideoViewForm";
            this.Text = "VideoViewForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VideoViewForm_FormClosing);
            this.Load += new System.EventHandler(this.VideoViewForm_Load);
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private VideoPlayerPanel videoPlayerPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox alarmCheckBox;
        private System.Windows.Forms.CheckBox regularCheckBox;
        private System.Windows.Forms.CheckBox detectCheckBox;
        private System.Windows.Forms.CheckBox manualCheckBox;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox cameraComboBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}