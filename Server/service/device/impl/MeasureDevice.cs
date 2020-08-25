using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Timers;
using SafeServer.dto;

namespace SafeServer.service.device
{
    public abstract class MeasureDevice : LtrDevice
    {
        private readonly SirenDev siren;
        private readonly Subject<DeviceStatus> reset;
        private readonly IConnectableObservable<DeviceStatus> status;
        private readonly Timer _timer;
        private readonly IDisposable _disposable;

        public MeasureDevice(Device device, IObservable<DeviceStatus> measure) : base(device)
        {
            reset = new Subject<DeviceStatus>();
            siren = new SirenDev(config.alarm);
            Add42(config.siren, siren.Siren);

            status = measure.Merge(reset)
                .Scan(DeviceStatus.Value(device, 0, false), (s, item) =>
                {
                    var alarm = !item.reset && (s.alarm || item.alarm);
                    var val = item.HasValue() ? item.value : s.value;
                    return DeviceStatus.Value(device, val.Value, alarm);
                })
                .Publish();
            
            _timer = new Timer(config.timeout);
            _timer.Elapsed += Elapsed;
            _timer.AutoReset = false;
            _timer.Enabled = false;

            _disposable = status
                .DistinctUntilChanged(s => s.alarm)
                .Where(s => s.alarm)
                .Subscribe(s => siren.Play(true));
        }

        public override IObservable<DeviceStatus> Status()
        {
            return status;
        }

        public override void Init()
        {
            Reset();
            status.Connect();
        }

        public virtual void Reset()
        {
            reset.OnNext(DeviceStatus.Reset(device));
        }
        
        public void ResetAlarm()
        {
            siren.Play(false);
            if (!_timer.Enabled)
                _timer.Start();
        }

        public override void Close()
        {
            _disposable.Dispose();
        }

        private void Elapsed(object sender, ElapsedEventArgs e)
        {
            Reset();
        }
    }
}