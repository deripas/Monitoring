using System.Reactive.Linq;
using SafeServer.dto;

namespace SafeServer.service.device
{
    public class BoolMeasureDevice : MeasureDevice, IMeasureDevice
    {
        public BoolMeasureDevice(Device device)
            : base(device, GetBool41(device.Config.sensor)
                .ToBool()
                .Select(v => DeviceStatus.Value(device, v)))
        {
        }
    }
}