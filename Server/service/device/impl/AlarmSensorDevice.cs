using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Timers;
using SafeServer.dto;

namespace SafeServer.service.device
{
    public abstract class AlarmSensorDevice : LtrDevice
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        private readonly SirenDev siren;
        private readonly Subject<DeviceStatus> reset;
        private readonly Subject<DeviceStatus> status;
        private readonly BehaviorSubject<bool> enable;
        private readonly Timer _timer;
        private readonly List<IDisposable> _disposables;

        public AlarmSensorDevice(Device device) : base(device)
        {
            _disposables = new List<IDisposable>();
            enable = new BehaviorSubject<bool>(IsEnable());
            reset = new Subject<DeviceStatus>();
            status = new Subject<DeviceStatus>();
            siren = new SirenDev();
            siren.Config(Config.alarm);

            Add42(Config.siren, siren.Siren);

            _timer = new Timer(Config.alarm.timeout);
            _timer.Elapsed += Elapsed;
            _timer.AutoReset = false;
            _timer.Enabled = false;
        }

        protected void Sensor(IObservable<DeviceStatus> measure)
        {
            _(measure.Merge(reset)
                .Scan(DeviceStatus.Reset(Id), ValueAgregate)
                .CombineLatest(enable, (s, e) =>
                {
                    s.alarm = e ? s.alarm : 0;
                    s.value = e ? s.value : 0;
                    return s;
                })
                .Subscribe(status));

            _(status
                .DistinctUntilChanged(s => s.alarm)
                .Where(s => s.alarm > 0)
                .Subscribe(s => siren.Play(true)));
        }

        protected virtual DeviceStatus ValueAgregate(DeviceStatus old, DeviceStatus cur)
        {
            if (cur.alarm < 0)
            {
                return DeviceStatus.Value(Id, old.value);
            }
            else
            {
                var alert = old.alarm > 0 ? old.alarm : cur.alarm;
                return DeviceStatus.Value(Id, cur.value, alert);
            }
        }

        public override IObservable<DeviceStatus> Status()
        {
            return status.Select(s =>
                  {
                      s.enable = IsEnable();
                      return s;
                  });
        }

        public override void Init()
        {
            Reset();
            Log.Info("{}({}) init", Name, Id);
        }

        public virtual void Reset()
        {
            reset.OnNext(DeviceStatus.Reset(Id));
        }

        public void ResetAlarm()
        {
            siren.Play(false);
            if (!_timer.Enabled)
                _timer.Start();
        }

        public void Peak()
        {
            siren.Peak();
        }

        public override void Close()
        {
            _disposables.ForEach(d => d.Dispose());
            _disposables.Clear();
            Log.Info("{}({}) close", Name, Id);
        }

        private void Elapsed(object sender, ElapsedEventArgs e)
        {
            Reset();
        }

        protected void _(IDisposable d)
        {
            _disposables.Add(d);
        }

        public override void Update(Config cfg)
        {
            base.Update(cfg);

            if (cfg.alarm != null)
            {
                Config.alarm = cfg.alarm;
                siren.Config(cfg.alarm);
                _timer.Interval = cfg.alarm.timeout;
                Log.Info("{}({}) update alert config {}", Name, Id, cfg.alarm);
            }
            Close();
            Init();
            Log.Info("{}({}) update configuration", Name, Id);
        }

        public override void OnEnableChange(bool value)
        {
            enable?.OnNext(value);
        }
    }
}