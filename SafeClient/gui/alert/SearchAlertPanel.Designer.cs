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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonExport = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBoxDevice = new System.Windows.Forms.ComboBox();
            this.alertListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.applyAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toLastAlertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanel1.Controls.Add(this.buttonExport, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxDevice, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.alertListView, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(400, 690);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonExport
            // 
            this.buttonExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExport.Location = new System.Drawing.Point(4, 620);
            this.buttonExport.Margin = new System.Windows.Forms.Padding(4);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(392, 66);
            this.buttonExport.TabIndex = 16;
            this.buttonExport.Text = "🖫";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(4, 4);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(392, 29);
            this.dateTimePicker1.TabIndex = 12;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
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
            this.comboBoxDevice.Location = new System.Drawing.Point(4, 48);
            this.comboBoxDevice.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxDevice.Name = "comboBoxDevice";
            this.comboBoxDevice.Size = new System.Drawing.Size(392, 32);
            this.comboBoxDevice.TabIndex = 15;
            this.comboBoxDevice.SelectedIndexChanged += new System.EventHandler(this.comboBoxDevice_SelectedIndexChanged);
            // 
            // alertListView
            // 
            this.alertListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.alertListView.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.alertListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.alertListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alertListView.FullRowSelect = true;
            this.alertListView.GridLines = true;
            this.alertListView.HideSelection = false;
            this.alertListView.Location = new System.Drawing.Point(4, 92);
            this.alertListView.Margin = new System.Windows.Forms.Padding(4);
            this.alertListView.MultiSelect = false;
            this.alertListView.Name = "alertListView";
            this.alertListView.RightToLeftLayout = true;
            this.alertListView.Size = new System.Drawing.Size(392, 520);
            this.alertListView.TabIndex = 0;
            this.alertListView.UseCompatibleStateImageBehavior = false;
            this.alertListView.View = System.Windows.Forms.View.Details;
            this.alertListView.SelectedIndexChanged += new System.EventHandler(this.alertListView_SelectedIndexChanged);
            this.alertListView.DoubleClick += new System.EventHandler(this.alertListView_DoubleClick);
            this.alertListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.alertListView_MouseClick);
            this.alertListView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.alertListView_MouseUp);
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
            this.columnHeader3.Width = 200;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.applyAllToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(329, 76);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(328, 36);
            this.toolStripMenuItem1.Text = "Обработать выделенный";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // applyAllToolStripMenuItem
            // 
            this.applyAllToolStripMenuItem.Name = "applyAllToolStripMenuItem";
            this.applyAllToolStripMenuItem.Size = new System.Drawing.Size(328, 36);
            this.applyAllToolStripMenuItem.Text = "Обработать ВСЕ ранее";
            this.applyAllToolStripMenuItem.Click += new System.EventHandler(this.applyAllToolStripMenuItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findToolStripMenuItem,
            this.toLastAlertToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(458, 76);
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.Size = new System.Drawing.Size(457, 36);
            this.findToolStripMenuItem.Text = "Перейти к неподтвержденной тревоге";
            this.findToolStripMenuItem.Click += new System.EventHandler(this.findToolStripMenuItem_Click);
            // 
            // toLastAlertToolStripMenuItem
            // 
            this.toLastAlertToolStripMenuItem.Name = "toLastAlertToolStripMenuItem";
            this.toLastAlertToolStripMenuItem.Size = new System.Drawing.Size(457, 36);
            this.toLastAlertToolStripMenuItem.Text = "Перейти к последней тревоге";
            this.toLastAlertToolStripMenuItem.Click += new System.EventHandler(this.toLastAlertToolStripMenuItem_Click);
            // 
            // SearchAlertPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SearchAlertPanel";
            this.Size = new System.Drawing.Size(400, 690);
            this.Load += new System.EventHandler(this.SearchAlertPanel_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.ListView alertListView;
        private System.Windows.Forms.ToolStripMenuItem applyAllToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ComboBox comboBoxDevice;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;

        #endregion

        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.ToolStripMenuItem toLastAlertToolStripMenuItem;
    }
}
