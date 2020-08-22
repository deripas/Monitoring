using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using SafeServer.dto;

namespace SafeServer.service.device
{
    public class RolletDev : LtrDevice, ISensorDevice
    {
        private readonly IConnectableObservable<SensorStatus> status;
        
        private readonly Subject<bool> UP = new Subject<bool>();
        private readonly Subject<bool> DW = new Subject<bool>();
        public RolletDev(Device dev) : base(dev)
        {
            var config = device.Config;
            
            var sensor_1 = config.sensorUP;
            var ltr41_1 = Ltr41(sensor_1.GetSlot());
            var sensorUP = ltr41_1[sensor_1.index]
                .ToBool()
                .DistinctUntilChanged();
            
            var sensor_2 = config.sensorDW;
            var ltr41_2 = Ltr41(sensor_2.GetSlot());
            var sensorDW = ltr41_2[sensor_2.index]
                .ToBool()
                .DistinctUntilChanged();

            var motor_1 = config.motorUP;
            var ltr42_1 = Ltr42(motor_1.GetSlot());
            ltr42_1[motor_1.index] = UP
                .CombineLatest(sensorUP, (cmd, status) => cmd && !status);
            
            var motor_2 = config.motorDW;
            var ltr42_2 = Ltr42(motor_2.GetSlot());
            ltr42_2[motor_2.index] = DW
                .CombineLatest(sensorDW, (cmd, status) => cmd && !status);

            status = sensorUP
                .CombineLatest(sensorDW, (up, dw) => SensorStatus.Rollet(dev, up, dw))
                .Publish();
        }

        public override void Init()
        {
            status.Connect();
        }

        public override void Reset()
        {
            UP.OnNext(false);
            DW.OnNext(false);
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
        
        public void Stop()
        {
            UP.OnNext(false);
            DW.OnNext(false);
        }

        public override void Close()
        {
            Stop();
        }

        public IObservable<SensorStatus> Status()
        {
            return status;
        }
    }
}