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
            var x = GetDouble25(Config.sensorX);
            var y = GetDouble25(Config.sensorY);
            var z = x.Zip(y, CalcLen);
                
            Sensor(z.Select(v => DeviceStatus.Value(Id, v)));
            base.Init();
        }

        private static double CalcLen(Tuple<double[], int> x, Tuple<double[], int> y)
        {
            const int scale = 10;
            var value = 0.0;
            var (valX, lenX) = x;
            var (valY, lenY) = y;
            for (var i = 0; i < lenX && i < lenY; i++)
            {
                var len = CalcLen(valX[i] * scale, valY[i] * scale);
                value = Math.Max(value, len);
            }
            return value;
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