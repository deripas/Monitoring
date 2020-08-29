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
            var config = dev.Config;
            if (config != null)
            {
                baseSensor1.Max = config.porogMax.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                verticalProgressBar1.Maximum = (int) config.max;
                verticalProgressBar1.Minimum = (int) config.min;
            }
        }

        public void Update(SensorStatus status)
        {
            baseSensor1.Alarm = status.alarm > 0;
            baseSensor1.Value = status.value.Value.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

            var value = (int) status.value;
            if (value > verticalProgressBar1.Maximum) value = verticalProgressBar1.Maximum;
            if (value < verticalProgressBar1.Minimum) value = verticalProgressBar1.Minimum;
            verticalProgressBar1.Value = value;
        }
    }
}
