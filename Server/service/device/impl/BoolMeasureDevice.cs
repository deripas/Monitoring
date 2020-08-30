using System;
using System.Reactive.Linq;
using SafeServer.dto;

namespace SafeServer.service.device
{
    public class BoolMeasureDevice : AlarmSensorDevice, IMeasureDevice
    {
        public BoolMeasureDevice(Device device)
            : base(device, GetBool41(device.Config.sensor)
                .ToBool()
                .Select(v => DeviceStatus.Value(device, v)))
        {
        }

        public override string RenderStatusValue(DeviceStatus status)
        {
            return (status.value == 0).ToString();
        }
    }
}