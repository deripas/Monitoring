using System.Reactive.Linq;
using SafeServer.dto;

namespace SafeServer.service.device
{
    public class DoubleMeasureDev : AlarmSensorDevice, IMeasureDevice
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        public DoubleMeasureDev(Device device) : base(device)
        {
        }

        public override void Init()
        {
            var calibr = device.Config.calibr;
            Sensor(GetDouble27(device.Config.sensor)
                .ToMean()
                .Convert(4, 20, calibr.min, calibr.max)
                .Select(v => DeviceStatus.Value(device, v, v > calibr.porogMax || v < calibr.porogMin)));
            base.Init();
        }

        public override void Update(Config cfg)
        {
            if (cfg.calibr != null)
            {
                device.Config.calibr = cfg.calibr;
                Log.Info("{}({}) update calibr config {}", device.Name, device.Id, cfg.calibr);
            }

            base.Update(cfg);
        }

        public override string RenderStatusValue(DeviceStatus status)
        {
            return status.value.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}