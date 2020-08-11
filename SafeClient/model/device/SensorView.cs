using System.Windows.Forms;

namespace model.device
{
    public interface SensorView
    {
        Control GetControl();
        void Set(DeviceController dev);
    }
}
