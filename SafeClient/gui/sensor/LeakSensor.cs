using model.device;
using System.Windows.Forms;
using api.dto;
using Properties;

namespace gui
{
    public partial class LeakSensor : UserControl, SensorView
    {
        public LeakSensor()
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
        }

        public void Update(SensorStatus status)
        {
            Enabled = status.enable;
            baseSensor1.EnabledLed = status.enable;
            baseSensor1.SetAlarm(status.alarm);
            pictureBox1.Image = status.value > 0
                ? Resources.weather_showers_scattered
                : Resources.weather_fog;
        }
    }
}
