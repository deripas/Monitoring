namespace gui
{
    partial class SearchAlertPanel
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.alertListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.videoFileList1 = new gui.VideoFileList();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBoxDevice = new System.Windows.Forms.ComboBox();
            this.applyAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxDevice, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(400, 690);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 93);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.alertListView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.videoFileList1);
            this.splitContainer1.Size = new System.Drawing.Size(394, 594);
            this.splitContainer1.SplitterDistance = 325;
            this.splitContainer1.TabIndex = 1;
            // 
            // alertListView
            // 
            this.alertListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.alertListView.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.alertListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.alertListView.ContextMenuStrip = this.contextMenuStrip1;
            this.alertListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alertListView.FullRowSelect = true;
            this.alertListView.GridLines = true;
            this.alertListView.HideSelection = false;
            this.alertListView.Location = new System.Drawing.Point(0, 0);
            this.alertListView.MultiSelect = false;
            this.alertListView.Name = "alertListView";
            this.alertListView.RightToLeftLayout = true;
            this.alertListView.Size = new System.Drawing.Size(394, 325);
            this.alertListView.TabIndex = 0;
            this.alertListView.UseCompatibleStateImageBehavior = false;
            this.alertListView.View = System.Windows.Forms.View.Details;
            this.alertListView.SelectedIndexChanged += new System.EventHandler(this.alertListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Датчик";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Время";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Обработан";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 120;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.applyAllToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(303, 114);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(302, 36);
            this.toolStripMenuItem1.Text = "Обработать";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // videoFileList1
            // 
            this.videoFileList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoFileList1.Location = new System.Drawing.Point(0, 0);
            this.videoFileList1.Name = "videoFileList1";
            this.videoFileList1.Size = new System.Drawing.Size(394, 265);
            this.videoFileList1.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(3, 3);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(394, 29);
            this.dateTimePicker1.TabIndex = 12;
            // 
            // comboBoxDevice
            // 
            this.comboBoxDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDevice.FormattingEnabled = true;
            this.comboBoxDevice.Items.AddRange(new object[] {
            "Все",
            "Температура",
            "Давление"});
            this.comboBoxDevice.Location = new System.Drawing.Point(3, 48);
            this.comboBoxDevice.Name = "comboBoxDevice";
            this.comboBoxDevice.Size = new System.Drawing.Size(394, 32);
            this.comboBoxDevice.TabIndex = 15;
            this.comboBoxDevice.SelectedIndexChanged += new System.EventHandler(this.comboBoxDevice_SelectedIndexChanged);
            // 
            // applyAllToolStripMenuItem
            // 
            this.applyAllToolStripMenuItem.Name = "applyAllToolStripMenuItem";
            this.applyAllToolStripMenuItem.Size = new System.Drawing.Size(302, 36);
            this.applyAllToolStripMenuItem.Text = "Обработать все ранее";
            this.applyAllToolStripMenuItem.Click += new System.EventHandler(this.applyAllToolStripMenuItem_Click);
            // 
            // SearchAlertPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SearchAlertPanel";
            this.Size = new System.Drawing.Size(400, 690);
            this.Load += new System.EventHandler(this.SearchAlertPanel_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBoxDevice;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private VideoFileList videoFileList1;
        private System.Windows.Forms.ListView alertListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem applyAllToolStripMenuItem;
    }
}
