using System;
using System.Reactive.Subjects;
using System.Threading;
using SafeServer.dto.config;

namespace SafeServer.service.device
{
    public class SirenDev
    {
        private Alarm config;
        private Subject<bool> siren;
        private volatile Thread _timer;
        private volatile bool _runnig;

        public IObservable<bool> Siren => siren;

        public SirenDev(Alarm alarm)
        {
            config = alarm;
            siren = new Subject<bool>();
        }

        public void Play(bool value)
        {
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
            Off();
            _runnig = false;
            _timer?.Join();
            _timer = null;
        }

        private void TimerCallback()
        {
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
            siren.OnNext(true);
        }

        private void Off()
        {
            siren.OnNext(false);
        }
    }
}