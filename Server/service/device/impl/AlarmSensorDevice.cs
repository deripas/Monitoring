using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Timers;
using NLog.Fluent;
using SafeServer.dto;

namespace SafeServer.service.device
{
    public abstract class AlarmSensorDevice : LtrDevice
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        private readonly SirenDev siren;
        private readonly Subject<DeviceStatus> reset;
        private readonly IConnectableObservable<DeviceStatus> status;
        private readonly Timer _timer;
        private readonly IDisposable _disposable;

        public AlarmSensorDevice(Device device, IObservable<DeviceStatus> measure) : base(device)
        {
            reset = new Subject<DeviceStatus>();
            siren = new SirenDev(config.alarm);
            Add42(config.siren, siren.Siren);

            status = measure.Merge(reset)
                .Scan(DeviceStatus.Reset(device), ValueAgregate)
                .Publish();
            
            _timer = new Timer(config.alarm.timeout);
            _timer.Elapsed += Elapsed;
            _timer.AutoReset = false;
            _timer.Enabled = false;

            _disposable = status
                .DistinctUntilChanged(s => s.alarm)
                .Where(s => s.alarm > 0)
                .Do(s =>
                {
                    Log.Warn("{0} Alert: {1} {2}", this, s.alarm, s.value);
                })
                .Subscribe(s => siren.Play(true));
        }

        public virtual DeviceStatus ValueAgregate(DeviceStatus old, DeviceStatus cur)
        {
            if(cur.alarm < 0)
            {
                return DeviceStatus.Value(device, old.value);
            }
            else
            {
                var alert = old.alarm > 0 ? old.alarm : cur.alarm;
                return DeviceStatus.Value(device, cur.value, alert);
            }
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