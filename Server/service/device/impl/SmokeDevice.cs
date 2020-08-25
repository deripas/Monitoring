using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using SafeServer.dto;

namespace SafeServer.service.device
{
    public class SmokeDevice : BoolMeasureDevice
    {
        private readonly Subject<bool> power = new Subject<bool>();

        public SmokeDevice(Device device) : base(device)
        {
            Add42(device.Config.power, power);
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
        
        public override void Close()
        {
            base.Close();
            power.OnNext(false);
        }
    }
}