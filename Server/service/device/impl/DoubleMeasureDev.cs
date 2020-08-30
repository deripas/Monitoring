using System.Reactive.Linq;
using SafeServer.dto;

namespace SafeServer.service.device
{
    public class DoubleMeasureDev : AlarmSensorDevice, IMeasureDevice
    {
        public DoubleMeasureDev(Device device)
            : base(device, GetDouble27(device.Config.sensor)
                .ToMean()
                .Convert(4, 20, device.Config.calibr.min, device.Config.calibr.max)
                .Select(v => DeviceStatus.Value(device, v, v > device.Config.calibr.porogMax || v < device.Config.calibr.porogMin)))
        {
        }
    }
}