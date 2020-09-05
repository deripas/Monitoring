using System;
using System.Windows.Forms;
using api.dto;

namespace model.device
{
    public interface SensorView
    {
        Control GetControl();
        void Set(DeviceController dev);
        void Update(SensorStatus status);
    }
}
