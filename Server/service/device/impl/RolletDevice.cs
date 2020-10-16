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
            var sensorUp = GetBool41(Config.sensorUP)
                .ToBool()
                .DistinctUntilChanged();
            
            var sensorDw = GetBool41(Config.sensorDW)
                .ToBool()
                .DistinctUntilChanged();

            Add42(Config.motorUP, UP
                .CombineLatest(sensorUp, (cmd, status) =>
                {
                    if(cmd && status) UP.OnNext(false);
                    return cmd && !status;
                }));

            Add42(Config.motorDW, DW
                .CombineLatest(sensorDw, (cmd, status) =>
                {
                    if(cmd && status) DW.OnNext(false);
                    return cmd && !status;
                }));

            status = sensorUp
                    .CombineLatest(sensorDw, (up, dw) => DeviceStatus.Rollet(Id, up, dw))
                    .Select(s =>
                    {
                        s.enable = IsEnable();
                        return s;
                    })
                ;
        }
        
        public override IObservable<DeviceStatus> Status()
        {
            return status;
        }

        public override void Init()
        {
            Log.Info("{}({}) init", Name, Id);
        }

        public void Up()
        {
            if (IsEnable())
            {
                Log.Info("{}({}) rollet UP", Name, Id);
                DW.OnNext(false);
                UP.OnNext(true);
            }
        }

        public void Down()
        {
            if (IsEnable())
            {
                Log.Info("{}({}) rollet DOWN", Name, Id);
                UP.OnNext(false);
                DW.OnNext(true);
            }
        }

        public void Stop()
        {
            Log.Info("{}({}) rollet STOP", Name, Id);
            UP.OnNext(false);
            DW.OnNext(false);
        }

        public override void Close()
        {
            Stop();
            Log.Info("{}({}) close", Name, Id);
        }

        public override string RenderStatusValue(DeviceStatus status)
        {
            return status.value switch
            {
                1 => "закрыт",
                2 => "открыт",
                _ => "-",
            };
        }
    }
}