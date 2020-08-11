using System.Windows.Forms;
using model.device;

namespace gui
{
    public partial class SmokeSensor : UserControl, SensorView
    {
        public SmokeSensor()
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
