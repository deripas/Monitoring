using System.Reactive.Linq;
using System.Reactive.Subjects;
using SafeServer.dto;

namespace SafeServer.service.device
{
    public class HurbleDevice : AlarmSensorDevice
    {
        private readonly Subject<bool> power = new Subject<bool>();

        public HurbleDevice(Device device)
            : base(device, GetBool41(device.Config.sensor)
                .ToBool()
                .Select(v => DeviceStatus.Value(device, v)))
        {
            Add42(device.Config.power, power);
        }
        
        public override void Close()
        {
            base.Close();
            power.OnNext(false);
        }

        public override string RenderStatusValue(DeviceStatus status)
        {
            return "?";
        }
    }
}