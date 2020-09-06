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
            enable = new BehaviorSubject<bool>(device.Enable);
            reset = new Subject<DeviceStatus>();
            status = new Subject<DeviceStatus>();
            siren = new SirenDev();
            siren.Config(config.alarm);

            Add42(config.siren, siren.Siren);

            _timer = new Timer(config.alarm.timeout);
            _timer.Elapsed += Elapsed;
            _timer.AutoReset = false;
            _timer.Enabled = false;
        }

        protected void Sensor(IObservable<DeviceStatus> measure)
        {
            _(measure.Merge(reset)
                .Scan(DeviceStatus.Reset(device), ValueAgregate)
                .CombineLatest(enable, (s, e) =>
                {
                    s.version = e ? s.version : -1;
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
            Log.Info("{}({}) init", device.Name, device.Id);
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

        public void Peak()
        {
            siren.Peak();
        }

        public override void Close()
        {
            _disposables.ForEach(d => d.Dispose());
            _disposables.Clear();
            Log.Info("{}({}) close", device.Name, device.Id);
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
            device.Version++;
            if (cfg.simple != null)
            {
                enable.OnNext(cfg.simple.enable);
                device.Enable = cfg.simple.enable;
                Log.Info("{}({}) enable status {}", device.Name, device.Id, cfg.simple.enable);
            }
            if (cfg.alarm != null)
            {
                device.Config.alarm = cfg.alarm;
                siren.Config(cfg.alarm);
                _timer.Interval = cfg.alarm.timeout;
                Log.Info("{}({}) update alert config {}", device.Name, device.Id, cfg.alarm);
            }
            Close();
            Init();
            Log.Info("{}({}) update configuration", device.Name, device.Id);
        }
    }
}