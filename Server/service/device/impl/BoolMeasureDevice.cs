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
                .Select(v => ToStatus(v)));
            base.Init();
        }

        public virtual DeviceStatus ToStatus(bool v)
        {
            return DeviceStatus.Value(Id, v);
        }

        public override string RenderStatusValue(DeviceStatus status)
        {
            return (status.alarm <= 0) ? "норма" : "тревога";
        }
    }
}