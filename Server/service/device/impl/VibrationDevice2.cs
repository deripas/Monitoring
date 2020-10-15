using System;
using System.Linq;
using System.Reactive.Linq;
using SafeServer.dto;

namespace SafeServer.service.device
{
    public class VibrationDevice2 : AlarmSensorDevice, IMeasureDevice
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        public VibrationDevice2(Device device) : base(device)
        {
        }
        
        public override void Init()
        {
            var x = GetDouble25(Config.sensorX);
            var y = GetDouble25(Config.sensorY);
            var z = x.Zip(y, CalcLen)
                .Do(v => Log.Info("{} = {}", Id, v)); ;
                
            Sensor(z.Select(v => DeviceStatus.Value(Id, v)));
            base.Init();
        }

        private static double CalcLen(Tuple<double[], int> x, Tuple<double[], int> y)
        {
            const int scale = 10;
            var skoX = sko(scale, x);
            var skoY = sko(scale, y);
            return CalcLen(skoX, skoY) * 1000;
        }

        private static double CalcLen(double x, double y)
        {
            return Math.Sqrt(x * x + y * y);
        }

        private static double sko(double scale, Tuple<double[], int> a)
        {
            var n = a.Item2;
            if (n < 1) return 0;

            var val = a.Item1.Take(n);
            var mean = val.Sum() / n;
            var sum = val
                .Select(v => Math.Pow(scale * (v - mean), 2))
                .Sum();
            return Math.Sqrt(sum / n);
        }

        public override string RenderStatusValue(DeviceStatus status)
        {
            var unit = " ?";
            return status.value.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + unit;
        }
    }
}