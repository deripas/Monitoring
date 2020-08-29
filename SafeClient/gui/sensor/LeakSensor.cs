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
            baseSensor1.Alarm = status.alarm > 0;
            pictureBox1.Image = status.alarm > 0
                ? Resources.weather_fog
                : Resources.weather_showers_scattered;
        }
    }
}
