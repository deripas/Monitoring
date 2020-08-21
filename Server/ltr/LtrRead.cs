using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;

namespace SafeServer.ltr
{
    public abstract class LtrRead<T>
    {
        public IObservable<T> Data => data.ObserveOn(NewThreadScheduler.Default);

        private Thread _timer;
        private volatile bool _running;
        private readonly Subject<T> data = new Subject<T>();

        public void Start()
        {
            _running = true;
            _timer = new Thread(TimerCallback);
            _timer.Start();
        }

        public void Stop()
        {
            _running = false;
            _timer?.Join();
            _timer = null;
            data.OnCompleted();
            data.Dispose();
        }

        private void TimerCallback()
        {
            while (_running)
            {
                data.OnNext(ReadItem());
                Thread.Sleep(10);
            }
        }

        protected abstract T ReadItem();
    }
}
