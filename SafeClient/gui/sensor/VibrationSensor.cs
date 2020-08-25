using model.device;
using System.Windows.Forms;
using api.dto;

namespace gui
{
    public partial class VibrationSensor : UserControl, SensorView
    {
        public VibrationSensor()
        {
            InitializeComponent();
        }

        public Control GetControl()
        {
            return this;
        }

        public void Set(DeviceController dev)
        {
            baseSensor1.Device = dev;
        }

        public void Update(SensorStatus status)
        {
            baseSensor1.Alarm = status.alarm;
            baseSensor1.Value = status.value.Value.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
            aGauge1.Value = (float) status.value;
        }
    }
}
