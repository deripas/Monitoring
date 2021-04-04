using model.device;
using System.Windows.Forms;
using api.dto;

namespace gui
{
    public partial class PressureSensor : UserControl, SensorView
    {
        public PressureSensor()
        {
            InitializeComponent();
            baseSensor1.Value = "";
            baseSensor1.Max = "";
        }

        public Control GetControl()
        {
            return this;
        }

        public void Set(DeviceController dev)
        {
            baseSensor1.Device = dev;
            var config = dev.Config?.calibr;
            if (config != null)
            {
                var max = config.porogMax.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                var min = config.porogMin.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                baseSensor1.Max = min + "/" + max;
                verticalProgressBar1.Maximum = (int) config.max;
                verticalProgressBar1.Minimum = (int) config.min;
            }
        }

        public void Update(SensorStatus status)
        {
            //Enabled = status.enable;
            baseSensor1.Enabled = status.enable;
            baseSensor1.EnabledLed = status.enable;
            baseSensor1.SetAlarm(status.alarm);
            baseSensor1.Value = status.value.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

            var value = (int) status.value;
            if (value > verticalProgressBar1.Maximum) value = verticalProgressBar1.Maximum;
            if (value < verticalProgressBar1.Minimum) value = verticalProgressBar1.Minimum;
            verticalProgressBar1.Value = value;
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            baseSensor1.ShowEditForm();
        }
    }
}
