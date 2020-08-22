using System;
using System.Reactive.Linq;
using SafeServer.dto;

namespace SafeServer.service.device
{
    public class PressureDev : SensorDevice
    {
        public PressureDev(Device device) : base(device)
        {
        }

        protected override IObservable<SensorStatus> CreateStatus()
        {
            var config = device.Config;
            var ch1 = config.sensor;
            var ltr27 = Ltr27(ch1.GetSlot());
            return ltr27[ch1.index]
                .ToMean()
                .Convert(4, 20, config.min, config.max)
                .Select(v => SensorStatus.Value(device, v, !double.IsNaN(v) && v > config.porog));
        }
    }
}