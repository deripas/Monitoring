using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SafeServer.dto;

namespace SafeServer.service.device
{
    public class SmokeDevice : BoolMeasureDevice
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        private readonly Subject<bool> power = new Subject<bool>();
        private readonly int resetTimeout;

        public SmokeDevice(Device device) : base(device)
        {
            resetTimeout = ConfigurationBinder.GetValue<int>(DI.Instance.Config, "Settings:PowerResetTimeout");
            Add42(device.Config.power, power);
        }

        protected override DeviceStatus ToStatus(bool v)
        {
            return DeviceStatus.Value(Id, !v);
        }

        public override void Reset()
        {
            base.Reset();
            Task.Run(() =>
            {
                power.OnNext(false);
                Thread.Sleep(resetTimeout);
                power.OnNext(true);
            });
        }
        
        public override void Close()
        {
            base.Close();
            power.OnNext(false);
        }
    }
}