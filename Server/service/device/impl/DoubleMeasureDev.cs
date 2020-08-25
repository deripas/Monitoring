using System.Reactive.Linq;
using SafeServer.dto;

namespace SafeServer.service.device
{
    public class DoubleMeasureDev : MeasureDevice, IMeasureDevice
    {
        public DoubleMeasureDev(Device device)
            : base(device, GetDouble27(device.Config.sensor)
                .ToMean()
                .Convert(4, 20, device.Config.min, device.Config.max)
                .Select(v => DeviceStatus.Value(device, v, v > device.Config.porogMax || v < device.Config.porogMin)))
        {
        }
    }
}