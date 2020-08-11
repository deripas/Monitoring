using model.device;
using System.Windows.Forms;

namespace gui
{
    public partial class LeakSensor : UserControl, SensorView
    {
        public LeakSensor()
        {
            InitializeComponent();
        }

        public Control GetControl()
        {
            return this;
        }

        public void Set(DeviceController dev)
        {
            baseSensor1.Description = dev.Description;
        }
    }
}
