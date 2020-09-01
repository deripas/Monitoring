using SafeServer.dto;

namespace SafeServer.service.device
{
    public class WaterDevice : BoolMeasureDevice
    {
        public WaterDevice(Device device) : base(device)
        {

        }

        public override DeviceStatus ValueAgregate(DeviceStatus old, DeviceStatus cur)
        {
            if (cur.alarm < 0)
            {
                var alert = old.value > 0 ? old.alarm : cur.alarm;
                return DeviceStatus.Value(device, old.value, alert);
            }
            else
            {
                var alert = old.alarm > 0 ? old.alarm : cur.alarm;
                return DeviceStatus.Value(device, cur.value, alert);
            }
        }
    }
}