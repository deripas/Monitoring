using model.device;
using System.Windows.Forms;
using api.dto;

namespace gui
{
    public partial class TemperatureSensor : UserControl, SensorView
    {
        public TemperatureSensor()
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
                baseSensor1.Max = config.porogMax.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                verticalProgressBar1.Maximum = (int) (config.max * 1.1);
            }
        }

        public void Update(SensorStatus status)
        {
            baseSensor1.SetAlarm(status.alarm);
            baseSensor1.Value = status.value.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
            verticalProgressBar1.Value = (int) status.value;
        }
    }
}
