﻿using System.Reactive.Linq;
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
            var calibr = Config.calibr;
            Sensor(GetDouble27(Config.sensor)
                .ToMean()
                .Where(v => v >= 4)
                .Convert(4, 20, calibr.min, calibr.max)
                .Select(v => DeviceStatus.Value(Id, v, v > calibr.porogMax || v < calibr.porogMin)));
            base.Init();
        }

        public override void Update(Config cfg)
        {
            if (cfg.calibr != null)
            {
                Config.calibr = cfg.calibr;
                Log.Info("{}({}) update calibr config {}", Name, Id, cfg.calibr);
            }
            base.Update(cfg);
        }

        public override string RenderStatusValue(DeviceStatus status)
        {
            var unit = "";
            if (Type.Equals("pressure"))
                unit = " бар";
            if (Type.Equals("temperature"))
                unit = "°C";

            return status.value.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + unit;
        }
    }
}