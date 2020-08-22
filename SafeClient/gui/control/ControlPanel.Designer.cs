namespace gui
{
    partial class ControlPanel
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rolletControl1 = new gui.RolletControl();
            this.rolletControl2 = new gui.RolletControl();
            this.classicHurbleControl1 = new gui.ClassicHurbleControl();
            this.classicHurbleControl2 = new gui.ClassicHurbleControl();
            this.circleHurbleControl1 = new gui.CircleHurbleControl();
            this.circleHurbleControl2 = new gui.CircleHurbleControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 700F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 700F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 700F));
            this.tableLayoutPanel1.Controls.Add(this.rolletControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rolletControl2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.classicHurbleControl1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.classicHurbleControl2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.circleHurbleControl1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.circleHurbleControl2, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(2200, 165);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // rolletControl1
            // 
            this.rolletControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rolletControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rolletControl1.Location = new System.Drawing.Point(3, 3);
            this.rolletControl1.Name = "rolletControl1";
            this.rolletControl1.Size = new System.Drawing.Size(694, 76);
            this.rolletControl1.TabIndex = 0;
            // 
            // rolletControl2
            // 
            this.rolletControl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rolletControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rolletControl2.Location = new System.Drawing.Point(3, 85);
            this.rolletControl2.Name = "rolletControl2";
            this.rolletControl2.Size = new System.Drawing.Size(694, 77);
            this.rolletControl2.TabIndex = 1;
            // 
            // classicHurbleControl1
            // 
            this.classicHurbleControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.classicHurbleControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.classicHurbleControl1.Location = new System.Drawing.Point(703, 3);
            this.classicHurbleControl1.Name = "classicHurbleControl1";
            this.classicHurbleControl1.Size = new System.Drawing.Size(694, 76);
            this.classicHurbleControl1.TabIndex = 2;
            // 
            // classicHurbleControl2
            // 
            this.classicHurbleControl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.classicHurbleControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.classicHurbleControl2.Location = new System.Drawing.Point(703, 85);
            this.classicHurbleControl2.Name = "classicHurbleControl2";
            this.classicHurbleControl2.Size = new System.Drawing.Size(694, 77);
            this.classicHurbleControl2.TabIndex = 3;
            // 
            // circleHurbleControl1
            // 
            this.circleHurbleControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.circleHurbleControl1.Location = new System.Drawing.Point(1403, 3);
            this.circleHurbleControl1.Name = "circleHurbleControl1";
            this.circleHurbleControl1.Size = new System.Drawing.Size(794, 76);
            this.circleHurbleControl1.TabIndex = 4;
            // 
            // circleHurbleControl2
            // 
            this.circleHurbleControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.circleHurbleControl2.Location = new System.Drawing.Point(1403, 85);
            this.circleHurbleControl2.Name = "circleHurbleControl2";
            this.circleHurbleControl2.Size = new System.Drawing.Size(794, 77);
            this.circleHurbleControl2.TabIndex = 5;
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ControlPanel";
            this.Size = new System.Drawing.Size(760, 108);
            this.Load += new System.EventHandler(this.ControlPanel_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private RolletControl rolletControl1;
        private RolletControl rolletControl2;
        private ClassicHurbleControl classicHurbleControl1;
        private ClassicHurbleControl classicHurbleControl2;
        private CircleHurbleControl circleHurbleControl1;
        private CircleHurbleControl circleHurbleControl2;
    }
}
