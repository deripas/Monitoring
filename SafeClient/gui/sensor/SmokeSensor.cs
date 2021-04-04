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
            pictureBox1.Image = Resources.no_fire;
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
            //Enabled = status.enable;
            baseSensor1.Enabled = status.enable;
            baseSensor1.EnabledLed = status.enable;
            baseSensor1.SetAlarm(status.alarm);
            pictureBox1.Image = status.alarm > 0
                ? Resources.fire
                : Resources.no_fire;
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            baseSensor1.ShowEditForm();
        }
    }
}
