using model.device;
using System.Windows.Forms;

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
            baseSensor1.Description = dev.Description;
        }
    }
}
