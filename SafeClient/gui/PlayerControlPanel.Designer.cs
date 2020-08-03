﻿namespace gui
{
    partial class PlayerControlPanel
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
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.checkBoxPause = new System.Windows.Forms.CheckBox();
            this.buttonSlow = new System.Windows.Forms.Button();
            this.buttonFast = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxSound = new System.Windows.Forms.CheckBox();
            this.buttonNextFrame = new System.Windows.Forms.Button();
            this.buttonPrevFrame = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPlay
            // 
            this.buttonPlay.Enabled = false;
            this.buttonPlay.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPlay.Location = new System.Drawing.Point(20, 3);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(81, 59);
            this.buttonPlay.TabIndex = 6;
            this.buttonPlay.Text = "▶";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonStop.Location = new System.Drawing.Point(107, 3);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(81, 59);
            this.buttonStop.TabIndex = 7;
            this.buttonStop.Text = "■";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // checkBoxPause
            // 
            this.checkBoxPause.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxPause.Enabled = false;
            this.checkBoxPause.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxPause.Location = new System.Drawing.Point(194, 3);
            this.checkBoxPause.Name = "checkBoxPause";
            this.checkBoxPause.Size = new System.Drawing.Size(81, 59);
            this.checkBoxPause.TabIndex = 8;
            this.checkBoxPause.Text = "⏯";
            this.checkBoxPause.UseVisualStyleBackColor = true;
            this.checkBoxPause.CheckedChanged += new System.EventHandler(this.checkBoxPause_CheckedChanged);
            // 
            // buttonSlow
            // 
            this.buttonSlow.Enabled = false;
            this.buttonSlow.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSlow.Location = new System.Drawing.Point(281, 3);
            this.buttonSlow.Name = "buttonSlow";
            this.buttonSlow.Size = new System.Drawing.Size(81, 59);
            this.buttonSlow.TabIndex = 9;
            this.buttonSlow.Text = "⏪";
            this.buttonSlow.UseVisualStyleBackColor = true;
            this.buttonSlow.Click += new System.EventHandler(this.buttonSlow_Click);
            // 
            // buttonFast
            // 
            this.buttonFast.Enabled = false;
            this.buttonFast.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFast.Location = new System.Drawing.Point(368, 3);
            this.buttonFast.Name = "buttonFast";
            this.buttonFast.Size = new System.Drawing.Size(81, 59);
            this.buttonFast.TabIndex = 10;
            this.buttonFast.Text = "⏩";
            this.buttonFast.UseVisualStyleBackColor = true;
            this.buttonFast.Click += new System.EventHandler(this.buttonFast_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.AutoSize = true;
            this.buttonNext.Enabled = false;
            this.buttonNext.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonNext.Location = new System.Drawing.Point(716, 3);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(81, 59);
            this.buttonNext.TabIndex = 11;
            this.buttonNext.Text = "➥";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonNext);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxSound);
            this.flowLayoutPanel1.Controls.Add(this.buttonNextFrame);
            this.flowLayoutPanel1.Controls.Add(this.buttonPrevFrame);
            this.flowLayoutPanel1.Controls.Add(this.buttonFast);
            this.flowLayoutPanel1.Controls.Add(this.buttonSlow);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxPause);
            this.flowLayoutPanel1.Controls.Add(this.buttonStop);
            this.flowLayoutPanel1.Controls.Add(this.buttonPlay);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(55, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 69);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // checkBoxSound
            // 
            this.checkBoxSound.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxSound.Enabled = false;
            this.checkBoxSound.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxSound.Location = new System.Drawing.Point(629, 3);
            this.checkBoxSound.Name = "checkBoxSound";
            this.checkBoxSound.Size = new System.Drawing.Size(81, 59);
            this.checkBoxSound.TabIndex = 15;
            this.checkBoxSound.Text = "🔈";
            this.checkBoxSound.UseVisualStyleBackColor = true;
            this.checkBoxSound.CheckedChanged += new System.EventHandler(this.checkBoxSound_CheckedChanged);
            // 
            // buttonNextFrame
            // 
            this.buttonNextFrame.Enabled = false;
            this.buttonNextFrame.Font = new System.Drawing.Font("Bahnschrift", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonNextFrame.Location = new System.Drawing.Point(542, 3);
            this.buttonNextFrame.Name = "buttonNextFrame";
            this.buttonNextFrame.Size = new System.Drawing.Size(81, 59);
            this.buttonNextFrame.TabIndex = 12;
            this.buttonNextFrame.Text = "⭲";
            this.buttonNextFrame.UseVisualStyleBackColor = true;
            this.buttonNextFrame.Click += new System.EventHandler(this.buttonNextFrame_Click);
            // 
            // buttonPrevFrame
            // 
            this.buttonPrevFrame.Enabled = false;
            this.buttonPrevFrame.Font = new System.Drawing.Font("Bahnschrift", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrevFrame.Location = new System.Drawing.Point(455, 3);
            this.buttonPrevFrame.Name = "buttonPrevFrame";
            this.buttonPrevFrame.Size = new System.Drawing.Size(81, 59);
            this.buttonPrevFrame.TabIndex = 13;
            this.buttonPrevFrame.Text = "⭰";
            this.buttonPrevFrame.UseVisualStyleBackColor = true;
            this.buttonPrevFrame.Click += new System.EventHandler(this.buttonPrevFrame_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(911, 75);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // PlayerControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PlayerControlPanel";
            this.Size = new System.Drawing.Size(911, 75);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.CheckBox checkBoxPause;
        private System.Windows.Forms.Button buttonSlow;
        private System.Windows.Forms.Button buttonFast;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonNextFrame;
        private System.Windows.Forms.Button buttonPrevFrame;
        private System.Windows.Forms.CheckBox checkBoxSound;
    }
}
