using model.device;
using System.Windows.Forms;
using api.dto;

namespace gui
{
    public partial class VibrationSensor : UserControl, SensorView
    {
        private float MaxValue = 1000;

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
            baseSensor1.Max = dev.Config.vibr.porog.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
            aGauge1.MaxValue = 10.0f;
            MaxValue = (float)(2 * dev.Config.vibr.porog);
        }

        public void Update(SensorStatus status)
        {
            Enabled = status.enable;
            baseSensor1.EnabledLed = status.enable;
            baseSensor1.SetAlarm(status.alarm);
            baseSensor1.Value = status.value.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
            aGauge1.Value = aGauge1.MaxValue * (float) status.value / MaxValue;
        }

        private void aGauge1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            baseSensor1.ShowEditForm();
        }
    }
}
