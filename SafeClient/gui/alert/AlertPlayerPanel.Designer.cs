﻿namespace gui
{
    partial class AlertPlayerPanel
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.speedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.canvasPanel1 = new gui.CanvasPanel();
            this.playerNavigationPanel1 = new gui.PlayerNavigationPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.speedLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 714);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1233, 39);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // speedLabel
            // 
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(170, 30);
            this.speedLabel.Text = "Файл не выбран";
            // 
            // chart1
            // 
            chartArea1.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Milliseconds;
            chartArea1.AxisX.LabelStyle.Format = "hh:mm:ss";
            chartArea1.CursorX.LineColor = System.Drawing.Color.Blue;
            chartArea1.CursorX.LineWidth = 3;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1233, 245);
            this.chart1.TabIndex = 6;
            this.chart1.Text = "chart1";
            this.chart1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseDown);
            // 
            // canvasPanel1
            // 
            this.canvasPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvasPanel1.Location = new System.Drawing.Point(0, 0);
            this.canvasPanel1.Name = "canvasPanel1";
            this.canvasPanel1.Ratio = 0.75D;
            this.canvasPanel1.Selected = false;
            this.canvasPanel1.Size = new System.Drawing.Size(1233, 350);
            this.canvasPanel1.TabIndex = 5;
            // 
            // playerNavigationPanel1
            // 
            this.playerNavigationPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.playerNavigationPanel1.Location = new System.Drawing.Point(0, 599);
            this.playerNavigationPanel1.Name = "playerNavigationPanel1";
            this.playerNavigationPanel1.Size = new System.Drawing.Size(1233, 115);
            this.playerNavigationPanel1.TabIndex = 4;
            this.playerNavigationPanel1.VideoPlayer = null;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.canvasPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chart1);
            this.splitContainer1.Size = new System.Drawing.Size(1233, 599);
            this.splitContainer1.SplitterDistance = 350;
            this.splitContainer1.TabIndex = 7;
            // 
            // AlertPlayerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.playerNavigationPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "AlertPlayerPanel";
            this.Size = new System.Drawing.Size(1233, 753);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel speedLabel;
        private PlayerNavigationPanel playerNavigationPanel1;
        private CanvasPanel canvasPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
