using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using SafeServer.dto;

namespace SafeServer.service.device
{
    public class RolletDevice : LtrDevice
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        private readonly IObservable<DeviceStatus> status;
        private readonly Subject<bool> UP = new Subject<bool>();
        private readonly Subject<bool> DW = new Subject<bool>();
        
        public RolletDevice(Device dev) : base(dev)
        {
            var sensorUp = GetBool41(config.sensorUP)
                .ToBool()
                .DistinctUntilChanged();
            
            var sensorDw = GetBool41(config.sensorDW)
                .ToBool()
                .DistinctUntilChanged();

            Add42(config.motorUP, UP
                .CombineLatest(sensorUp, (cmd, status) =>
                {
                    if(cmd && status) UP.OnNext(false);
                    return cmd && !status;
                }));

            Add42(config.motorDW, DW
                .CombineLatest(sensorDw, (cmd, status) =>
                {
                    if(cmd && status) DW.OnNext(false);
                    return cmd && !status;
                }));

            status = sensorUp
                    .CombineLatest(sensorDw, (up, dw) => DeviceStatus.Rollet(dev, up, dw))
                ;
        }
        
        public override IObservable<DeviceStatus> Status()
        {
            return status;
        }

        public override void Init()
        {
            Log.Info("{}({}) init", device.Name, device.Id);
        }

        public void Up()
        {
            if (device.Enable)
            {
                Log.Info("{}({}) rollet UP", device.Name, device.Id);
                DW.OnNext(false);
                UP.OnNext(true);
            }
        }

        public void Down()
        {
            if (device.Enable)
            {
                Log.Info("{}({}) rollet DOWN", device.Name, device.Id);
                UP.OnNext(false);
                DW.OnNext(true);
            }
        }

        public void Stop()
        {
            Log.Info("{}({}) rollet STOP", device.Name, device.Id);
            UP.OnNext(false);
            DW.OnNext(false);
        }

        public override void Close()
        {
            Stop();
            Log.Info("{}({}) close", device.Name, device.Id);
        }

        public override string RenderStatusValue(DeviceStatus status)
        {
            return "?";
        }

        public override void Update(Config cfg)
        {
            device.Version++;
            if (cfg.simple != null)
            {
                Enable(cfg.simple.enable);
                Log.Info("{}({}) enable status {}", device.Name, device.Id, cfg.simple.enable);
            }
        }

        public override void Enable(bool val)
        {
            device.Enable = val;
        }
    }
}