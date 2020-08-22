using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using SafeServer.dto;

namespace SafeServer.service.device
{
    public abstract class SensorDevice : LtrDevice, ISensorDevice, IWithSirenDevice
    {
        private readonly Subject<SensorStatus> reset = new Subject<SensorStatus>();
        private readonly IConnectableObservable<SensorStatus> status;
        
        public SensorDevice(Device device) : base(device)
        {
            status = CreateStatus()
                .Merge(reset)
                .Scan(SensorStatus.Value(device, 0, false), (s, item) =>
                {
                    var alarm = item.enable && !item.reset && (s.alarm || item.alarm);
                    var val = !double.IsNaN(item.value.Value) ? item.value : s.value;
                    return SensorStatus.Value(device, val.Value, alarm);
                })
                .Publish();
        }

        protected abstract IObservable<SensorStatus> CreateStatus();
        
        public long SirenId()
        {
            return device.Config.siren;
        }

        public override void Init()
        {
            Reset();
            status.Connect();
        }

        public override void Reset()
        {
            reset.OnNext(SensorStatus.Reset(device));
        }

        public override void Close()
        {

        }

        public IObservable<bool> Siren()
        {
            return status
                .Select(s => s.alarm)
                .DistinctUntilChanged();
        }

        public IObservable<SensorStatus> Status()
        {
            return status;
        }
    }
}