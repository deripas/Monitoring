using System.Reactive.Linq;
using SafeServer.dto;

namespace SafeServer.service.device
{
    public class DoubleMeasureDev : AlarmSensorDevice, IMeasureDevice
    {
        public DoubleMeasureDev(Device device) : base(device)
        {
            var calibr = device.Config.calibr;
            Sensor(GetDouble27(device.Config.sensor)
                .ToMean()
                .Convert(4, 20, calibr.min, calibr.max)
                .Select(v => DeviceStatus.Value(device, v, v > calibr.porogMax || v < calibr.porogMin)));
        }

        public override string RenderStatusValue(DeviceStatus status)
        {
            return status.value.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}