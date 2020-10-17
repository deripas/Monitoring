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
            var scale = Config.vibr.scale;
            var x = GetDouble25(Config.sensorX)
                .Scale(1000.0 / Config.sensorX.cfg.sensitivity);

            var y = GetDouble25(Config.sensorY)
                .Scale(1000.0 / Config.sensorY.cfg.sensitivity);

            var z = x.Zip(y, CalcLen)
                  .Select(v => v * scale);

            Sensor(z.Select(v => DeviceStatus.Value(Id, v)));
            base.Init();
        }

        private static double CalcLen(Tuple<double[], int> x, Tuple<double[], int> y)
        {
            var value = 0.0;
            var (valX, lenX) = x;
            var (valY, lenY) = y;
            for (var i = 0; i < lenX && i < lenY; i++)
            {
                var len = CalcLen(valX[i], valY[i]);
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