using System.Windows.Forms;
using api.dto;
using model.device;
using Properties;

namespace gui
{
    public partial class SmokeSensor : UserControl, SensorView
    {
        public SmokeSensor()
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
            baseSensor1.Description = dev.Description;
        }

        public void Update(SensorStatus status)
        {
            baseSensor1.Alarm = status.alarm;
            pictureBox1.Image = status.alarm
                ? Resources.fire
                : Resources.no_fire;
        }
    }
}
