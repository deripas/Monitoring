﻿namespace gui
{
    partial class CameraViewPanel
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
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.soundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.talkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.streamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cameraToolStripMenuItem = new System.Windows.Forms.ToolStripComboBox();
            this.ratioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.pTZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.canvas = new gui.CanvasPanel();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenu
            // 
            this.contextMenu.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.soundToolStripMenuItem, this.talkToolStripMenuItem, this.streamToolStripMenuItem, this.cameraToolStripMenuItem, this.ratioToolStripMenuItem, this.pTZToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(331, 228);
            this.contextMenu.VisibleChanged += new System.EventHandler(this.contextMenu_VisibleChanged);
            // 
            // soundToolStripMenuItem
            // 
            this.soundToolStripMenuItem.CheckOnClick = true;
            this.soundToolStripMenuItem.Name = "soundToolStripMenuItem";
            this.soundToolStripMenuItem.Size = new System.Drawing.Size(330, 36);
            this.soundToolStripMenuItem.Text = "Звук";
            this.soundToolStripMenuItem.Click += new System.EventHandler(this.soundToolStripMenuItem_Click);
            // 
            // talkToolStripMenuItem
            // 
            this.talkToolStripMenuItem.CheckOnClick = true;
            this.talkToolStripMenuItem.Name = "talkToolStripMenuItem";
            this.talkToolStripMenuItem.Size = new System.Drawing.Size(330, 36);
            this.talkToolStripMenuItem.Text = "talk";
            this.talkToolStripMenuItem.Visible = false;
            this.talkToolStripMenuItem.Click += new System.EventHandler(this.talkToolStripMenuItem_Click);
            // 
            // streamToolStripMenuItem
            // 
            this.streamToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.mainToolStripMenuItem, this.subToolStripMenuItem});
            this.streamToolStripMenuItem.Name = "streamToolStripMenuItem";
            this.streamToolStripMenuItem.Size = new System.Drawing.Size(330, 36);
            this.streamToolStripMenuItem.Text = "Поток";
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(307, 38);
            this.mainToolStripMenuItem.Text = "Основной";
            this.mainToolStripMenuItem.Click += new System.EventHandler(this.mainToolStripMenuItem_Click);
            // 
            // subToolStripMenuItem
            // 
            this.subToolStripMenuItem.Name = "subToolStripMenuItem";
            this.subToolStripMenuItem.Size = new System.Drawing.Size(307, 38);
            this.subToolStripMenuItem.Text = "Дополнительный";
            this.subToolStripMenuItem.Click += new System.EventHandler(this.subToolStripMenuItem_Click);
            // 
            // cameraToolStripMenuItem
            // 
            this.cameraToolStripMenuItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cameraToolStripMenuItem.Name = "cameraToolStripMenuItem";
            this.cameraToolStripMenuItem.Size = new System.Drawing.Size(270, 40);
            this.cameraToolStripMenuItem.Visible = false;
            this.cameraToolStripMenuItem.SelectedIndexChanged += new System.EventHandler(this.cameraToolStripMenuItem_SelectedIndexChanged);
            // 
            // ratioToolStripMenuItem
            // 
            this.ratioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.toolStripMenuItem2, this.toolStripMenuItem3});
            this.ratioToolStripMenuItem.Name = "ratioToolStripMenuItem";
            this.ratioToolStripMenuItem.Size = new System.Drawing.Size(330, 36);
            this.ratioToolStripMenuItem.Text = "Аспект";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(158, 38);
            this.toolStripMenuItem2.Text = "4:3";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(158, 38);
            this.toolStripMenuItem3.Text = "16:9";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // pTZToolStripMenuItem
            // 
            this.pTZToolStripMenuItem.Name = "pTZToolStripMenuItem";
            this.pTZToolStripMenuItem.Size = new System.Drawing.Size(330, 36);
            this.pTZToolStripMenuItem.Text = "Ракурс";
            this.pTZToolStripMenuItem.Click += new System.EventHandler(this.pTZToolStripMenuItem_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.Black;
            this.canvas.ContextMenuStrip = this.contextMenu;
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(0, 0);
            this.canvas.Name = "canvas";
            this.canvas.Ratio = 0.75D;
            this.canvas.Selected = false;
            this.canvas.Size = new System.Drawing.Size(741, 590);
            this.canvas.TabIndex = 0;
            this.canvas.Load += new System.EventHandler(this.canvas_Load);
            // 
            // CameraViewPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.canvas);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "CameraViewPanel";
            this.Size = new System.Drawing.Size(741, 590);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ToolStripComboBox cameraToolStripMenuItem;
        private gui.CanvasPanel canvas;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem mainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pTZToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ratioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem soundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem streamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem talkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolTip toolTip1;

        #endregion
    }
}
