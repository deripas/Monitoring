using System;
using System.Reactive.Linq;
using SafeServer.dto;

namespace SafeServer.service.device
{
    public class BoolMeasureDevice : AlarmSensorDevice, IMeasureDevice
    {
        public BoolMeasureDevice(Device device) : base(device)
        {
        }

        public override void Init()
        {
            Sensor(GetBool41(device.Config.sensor)
                .ToBool()
                .Select(v => DeviceStatus.Value(device, v)));
            base.Init();
        }

        public override string RenderStatusValue(DeviceStatus status)
        {
            return (status.value == 0) ? "норма" : "тревога";
        }
    }
}