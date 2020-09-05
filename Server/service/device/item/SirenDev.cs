﻿using System;
using System.Reactive.Subjects;
using System.Reflection;
using System.Threading;
using SafeServer.dto.config;

namespace SafeServer.service.device
{
    public class SirenDev
    {
        private Subject<bool> siren;
        private volatile Thread _timer;
        private volatile bool _runnig;
        private volatile int count = 1;
        private volatile int delay = 0;
        private volatile int period = 0;

        public IObservable<bool> Siren => siren;

        public SirenDev()
        {
            siren = new Subject<bool>();
        }

        public void Config(Alarm config)
        {
            count = config.count;
            delay = config.delay;
            period = config.period;
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
            while (_runnig)
            {
                if (count <= 0)
                {
                    Off();
                    break;
                }

                count--;

                On();
                if (delay > 1) Thread.Sleep(delay);

                Off();
                if (period > 1) Thread.Sleep(period);
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

        public void Peak()
        {
            On();
            Off();
        }
    }
}