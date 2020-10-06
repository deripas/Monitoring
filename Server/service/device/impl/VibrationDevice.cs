using System;
using System.Reactive.Linq;
using SafeServer.dto;

namespace SafeServer.service.device
{
    public class VibrationDevice : AlarmSensorDevice, IMeasureDevice
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        public VibrationDevice(Device device) : base(device)
        {
        }
        
        public override void Init()
        {
            var x = GetDouble25(device.Config.sensorX)
                .FlatMap()
                .Select(v => v * 10);
            var y = GetDouble25(device.Config.sensorY)
                .FlatMap()
                .Select(v => v * 10);
            var z = x.Zip(y, CalcLen);
                
            Sensor(z.Select(v => DeviceStatus.Value(device, v)));
            base.Init();
        }

        private static double CalcLen(double x, double y)
        {
            return Math.Sqrt(x * x + y * y);
        }

        public override string RenderStatusValue(DeviceStatus status)
        {
            var unit = " g";
            return status.value.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + unit;
        }
    }
}