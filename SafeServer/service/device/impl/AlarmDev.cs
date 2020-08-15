using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading;
using SafeServer.dto;
using SafeServer.dto.config;

namespace SafeServer.service.device
{
    public class AlarmDev : LtrDevice, ISirenDevice
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        
        private Subject<bool> alarm = new Subject<bool>();
        private List<IDisposable> subscribers = new List<IDisposable>();
        
        private Thread _timer;
        private volatile bool _runnig;

        public AlarmDev(Device device) : base(device)
        {
            var config = device.Config;
            if (config == null)
            {
                config = new Config();
                config.alarm = new Alarm {sn = "2D551744", num = 2, index = 1, count = 3, delay = 1000, period = 2000};
                device.Config = config;
            }

            var ch = config.alarm;
            var ltr42 = Ltr42(ch.GetSlot());
            ltr42[ch.index] = alarm;
        }

        public override void Init()
        {
            Reset();
        }

        public override void Reset()
        {
            Stop();
        }
        
        public override void Close()
        {
            foreach (var subscriber in subscribers)
                subscriber.Dispose();
        }

        public void Subscribe(IObservable<bool> siren)
        {
            subscribers.Add(siren.Subscribe(Alert));
        }

        private void Alert(bool value)
        {
            Log.Info("{0} - Alert {1}", this, value);
            if(!device.Enable) return;
            
            if (value && !_runnig)
                Start();

            if (!value && _runnig)
                Stop();
        }

        private void Start()
        {
            _runnig = true;
            _timer = new Thread(TimerCallback);
            _timer.Start();
        }

        private void Stop()
        {
            _runnig = false;
            _timer?.Join();
            _timer = null;
            Off();
        }

        private void TimerCallback()
        {
            var config = device.Config.alarm;
            var count = config.count;
            while (_runnig)
            {
                if (count <= 0)
                {
                    Off();
                    break;
                }

                count--;

                On();
                if (config.delay > 1) Thread.Sleep(config.delay);

                Off();
                if (config.delay > 1) Thread.Sleep(config.delay);
            }
        }
        
        private void On()
        {
            alarm.OnNext(true);
        }

        private void Off()
        {
            alarm.OnNext(false);
        }
    }
}
