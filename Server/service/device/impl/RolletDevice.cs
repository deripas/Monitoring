using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using SafeServer.dto;

namespace SafeServer.service.device
{
    public class RolletDevice : LtrDevice
    {
        private readonly IConnectableObservable<DeviceStatus> status;
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
                .Publish();
        }
        
        public override IObservable<DeviceStatus> Status()
        {
            return status;
        }

        public override void Init()
        {
            status.Connect();
        }

        public void Up()
        {
            DW.OnNext(false);
            UP.OnNext(true);
        }

        public void Down()
        {
            UP.OnNext(false);
            DW.OnNext(true);
        }

        private void Stop()
        {
            UP.OnNext(false);
            DW.OnNext(false);
        }

        public override void Close()
        {
            Stop();
        }
    }
}