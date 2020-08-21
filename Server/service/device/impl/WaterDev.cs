using System;
using System.Reactive.Linq;
using SafeServer.dto;
using SafeServer.dto.config;

namespace SafeServer.service.device
{
    public class WaterDev : SensorDevice
    {
        public WaterDev(Device device) : base(device)
        {
        }

        protected override IObservable<SensorStatus> CreateStatus()
        {
            var config = device.Config;
            var ch1 = config.sensor;
            var ltr41 = Ltr41(ch1.GetSlot());
            return ltr41[ch1.index]
                .ToBool()
                .Select(v => SensorStatus.Value(device, v));
        }
    }
}