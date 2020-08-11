using model.device;
using System.Windows.Forms;

namespace gui
{
    public partial class PressureSensor : UserControl, SensorView
    {
        public PressureSensor()
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
