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
            Sensor(GetBool41(Config.sensor)
                .ToBool()
                .Select(v => DeviceStatus.Value(Id, v)));
            base.Init();
        }

        public override string RenderStatusValue(DeviceStatus status)
        {
            return (status.alarm <= 0) ? "норма" : "тревога";
        }
    }
}