﻿using System.ComponentModel;

namespace gui
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.MainLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.modeChangeButton = new System.Windows.Forms.ToolStripSplitButton();
            this.mode1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mode2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mode3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grid = new gui.CameraGridPanel();
            this.controlPanel1 = new gui.ControlPanel();
            this.sensorPanel1 = new gui.SensorPanel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton4,
            this.toolStripSeparator2,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripSeparator3,
            this.MainLabel,
            this.toolStripSeparator1,
            this.closeButton,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripButton7,
            this.toolStripButton8,
            this.toolStripButton9,
            this.modeChangeButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1588, 58);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.AutoToolTip = false;
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::Properties.Resources.icons8_камера_видеонаблюдения_96;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(52, 52);
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 58);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::Properties.Resources.icons8_видео_плейлист_64;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(52, 52);
            this.toolStripButton1.Text = "Архив видео";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::Properties.Resources.icons8_монитор_сердца_64;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(52, 52);
            this.toolStripButton2.Text = "Архив тревог";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::Properties.Resources.icons8_приборная_панель_96;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(52, 52);
            this.toolStripButton3.Text = "Редактор";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 58);
            // 
            // MainLabel
            // 
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(0, 52);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 58);
            // 
            // closeButton
            // 
            this.closeButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.closeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.closeButton.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeButton.Image = ((System.Drawing.Image)(resources.GetObject("closeButton.Image")));
            this.closeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(54, 52);
            this.closeButton.Text = "✕";
            this.closeButton.ToolTipText = "Закрыть";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(133, 52);
            this.toolStripButton5.Text = "Обзор";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(213, 52);
            this.toolStripButton6.Text = "Испытания";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(193, 52);
            this.toolStripButton7.Text = "Град.-ОРУ";
            this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(289, 52);
            this.toolStripButton8.Text = "Спящий режим";
            this.toolStripButton8.Click += new System.EventHandler(this.toolStripButton8_Click);
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton9.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(61, 52);
            this.toolStripButton9.Text = "🗕";
            this.toolStripButton9.ToolTipText = "Свернуть";
            this.toolStripButton9.Click += new System.EventHandler(this.toolStripButton9_Click);
            // 
            // modeChangeButton
            // 
            this.modeChangeButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.modeChangeButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mode1ToolStripMenuItem,
            this.mode2ToolStripMenuItem,
            this.mode3ToolStripMenuItem});
            this.modeChangeButton.Image = global::Properties.Resources.mode;
            this.modeChangeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.modeChangeButton.Name = "modeChangeButton";
            this.modeChangeButton.Size = new System.Drawing.Size(343, 52);
            this.modeChangeButton.Text = "Выбор режима";
            this.modeChangeButton.ToolTipText = "Режим";
            this.modeChangeButton.ButtonClick += new System.EventHandler(this.modeChangeButton_ButtonClick);
            // 
            // mode1ToolStripMenuItem
            // 
            this.mode1ToolStripMenuItem.Name = "mode1ToolStripMenuItem";
            this.mode1ToolStripMenuItem.Size = new System.Drawing.Size(438, 56);
            this.mode1ToolStripMenuItem.Text = "Испытания";
            this.mode1ToolStripMenuItem.Click += new System.EventHandler(this.mode1ToolStripMenuItem_Click);
            // 
            // mode2ToolStripMenuItem
            // 
            this.mode2ToolStripMenuItem.Name = "mode2ToolStripMenuItem";
            this.mode2ToolStripMenuItem.Size = new System.Drawing.Size(438, 56);
            this.mode2ToolStripMenuItem.Text = "Град.-ОРУ";
            this.mode2ToolStripMenuItem.Click += new System.EventHandler(this.mode2ToolStripMenuItem_Click);
            // 
            // mode3ToolStripMenuItem
            // 
            this.mode3ToolStripMenuItem.Name = "mode3ToolStripMenuItem";
            this.mode3ToolStripMenuItem.Size = new System.Drawing.Size(438, 56);
            this.mode3ToolStripMenuItem.Text = "Спящий режим";
            this.mode3ToolStripMenuItem.Click += new System.EventHandler(this.mode3ToolStripMenuItem_Click);
            // 
            // grid
            // 
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 58);
            this.grid.Margin = new System.Windows.Forms.Padding(2);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(980, 338);
            this.grid.TabIndex = 0;
            // 
            // controlPanel1
            // 
            this.controlPanel1.AutoScroll = true;
            this.controlPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.controlPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlPanel1.Location = new System.Drawing.Point(0, 396);
            this.controlPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.controlPanel1.Name = "controlPanel1";
            this.controlPanel1.Size = new System.Drawing.Size(980, 294);
            this.controlPanel1.TabIndex = 3;
            // 
            // sensorPanel1
            // 
            this.sensorPanel1.AutoScroll = true;
            this.sensorPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sensorPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.sensorPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sensorPanel1.Location = new System.Drawing.Point(980, 58);
            this.sensorPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.sensorPanel1.Name = "sensorPanel1";
            this.sensorPanel1.Size = new System.Drawing.Size(608, 632);
            this.sensorPanel1.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1588, 690);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.controlPanel1);
            this.Controls.Add(this.sensorPanel1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ToolStripButton closeButton;
        private gui.ControlPanel controlPanel1;
        private gui.CameraGridPanel grid;
        private gui.SensorPanel sensorPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripLabel MainLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;

        #endregion

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSplitButton modeChangeButton;
        private System.Windows.Forms.ToolStripMenuItem mode1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mode2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mode3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
    }
}