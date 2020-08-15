using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using SafeServer.dto;
using SafeServer.dto.config;

namespace SafeServer.service.device
{
    public class SmokeDev : SensorDevice
    {
        private readonly Subject<bool> power = new Subject<bool>();

        public SmokeDev(Device device) : base(device)
        {
            var config = device.Config;
            var ch2 = config.power;
            var ltr42 = Ltr42(ch2.GetSlot());
            ltr42[ch2.index] = power;
        }

        protected override IObservable<SensorStatus> CreateStatus()
        {
            var config = device.Config;
            if (config == null)
            {
                config = new Config();
                config.siren = 28;
                config.sensor = new Channel {sn = "2D551744", num = 1, index = 1};
                config.power = new Channel {sn = "2D551744", num = 2, index = 0};
                device.Config = config;
            }
            var ch1 = config.sensor;
            var ltr41 = Ltr41(ch1.GetSlot());
            return ltr41[ch1.index]
                .ToBool()
                .Select(v => SensorStatus.Value(device, v));
        }

        public override void Reset()
        {
            base.Reset();
            Task.Run(() =>
            {
                power.OnNext(false);
                Thread.Sleep(100);
                power.OnNext(true);
            });
        }
    }
}
