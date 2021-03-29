namespace gui
{
    partial class VibrationSensor
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
            this.aGauge1 = new System.Windows.Forms.AGauge();
            this.baseSensor1 = new gui.BaseSensor();
            this.SuspendLayout();
            // 
            // aGauge1
            // 
            this.aGauge1.BaseArcColor = System.Drawing.Color.Gray;
            this.aGauge1.BaseArcRadius = 35;
            this.aGauge1.BaseArcStart = 135;
            this.aGauge1.BaseArcSweep = 270;
            this.aGauge1.BaseArcWidth = 2;
            this.aGauge1.Center = new System.Drawing.Point(35, 35);
            this.aGauge1.Location = new System.Drawing.Point(4, 4);
            this.aGauge1.Margin = new System.Windows.Forms.Padding(4);
            this.aGauge1.MaxValue = 10F;
            this.aGauge1.MinValue = 0F;
            this.aGauge1.Name = "aGauge1";
            this.aGauge1.NeedleColor1 = System.Windows.Forms.AGaugeNeedleColor.Gray;
            this.aGauge1.NeedleColor2 = System.Drawing.Color.DimGray;
            this.aGauge1.NeedleRadius = 35;
            this.aGauge1.NeedleType = System.Windows.Forms.NeedleType.Advance;
            this.aGauge1.NeedleWidth = 2;
            this.aGauge1.ScaleLinesInterColor = System.Drawing.Color.Black;
            this.aGauge1.ScaleLinesInterInnerRadius = 27;
            this.aGauge1.ScaleLinesInterOuterRadius = 35;
            this.aGauge1.ScaleLinesInterWidth = 1;
            this.aGauge1.ScaleLinesMajorColor = System.Drawing.Color.Black;
            this.aGauge1.ScaleLinesMajorInnerRadius = 37;
            this.aGauge1.ScaleLinesMajorOuterRadius = 30;
            this.aGauge1.ScaleLinesMajorStepValue = 10F;
            this.aGauge1.ScaleLinesMajorWidth = 2;
            this.aGauge1.ScaleLinesMinorColor = System.Drawing.Color.Gray;
            this.aGauge1.ScaleLinesMinorInnerRadius = 27;
            this.aGauge1.ScaleLinesMinorOuterRadius = 35;
            this.aGauge1.ScaleLinesMinorTicks = 9;
            this.aGauge1.ScaleLinesMinorWidth = 1;
            this.aGauge1.ScaleNumbersColor = System.Drawing.Color.Black;
            this.aGauge1.ScaleNumbersFormat = null;
            this.aGauge1.ScaleNumbersRadius = 100;
            this.aGauge1.ScaleNumbersRotation = 0;
            this.aGauge1.ScaleNumbersStartScaleLine = 0;
            this.aGauge1.ScaleNumbersStepScaleLines = 1;
            this.aGauge1.Size = new System.Drawing.Size(114, 88);
            this.aGauge1.TabIndex = 14;
            this.aGauge1.Text = "aGauge1";
            this.aGauge1.Value = 0F;
            this.aGauge1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.aGauge1_MouseDoubleClick);
            // 
            // baseSensor1
            // 
            this.baseSensor1.Alarm = false;
            this.baseSensor1.Description = "";
            this.baseSensor1.Device = null;
            this.baseSensor1.EnabledLed = false;
            this.baseSensor1.Location = new System.Drawing.Point(0, 0);
            this.baseSensor1.Margin = new System.Windows.Forms.Padding(2);
            this.baseSensor1.Max = "maximum";
            this.baseSensor1.Name = "baseSensor1";
            this.baseSensor1.Size = new System.Drawing.Size(628, 117);
            this.baseSensor1.TabIndex = 0;
            this.baseSensor1.Title = "Вибрация";
            this.baseSensor1.Value = "current";
            // 
            // VibrationSensor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.aGauge1);
            this.Controls.Add(this.baseSensor1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "VibrationSensor";
            this.Size = new System.Drawing.Size(630, 96);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.AGauge aGauge1;
        private gui.BaseSensor baseSensor1;

        #endregion
    }
}
