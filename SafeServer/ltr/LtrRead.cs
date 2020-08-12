using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using System.Threading;

namespace SafeServer.ltr
{
    public abstract class LtrRead<T>
    {
        private Thread _timer;
        private volatile bool _running;
        private readonly Subject<T> _data = new Subject<T>();
        public IObservable<T> Data => _data;
        private readonly List<Subject<T>> sensors = new List<Subject<T>>();
        private readonly List<IDisposable> disposables = new List<IDisposable>();
        
        protected Subject<T> Add(Subject<T> subject)
        {
            sensors.Add(subject);
            return subject;
        }

        public void Start()
        {
            foreach (var subject in sensors)
                disposables.Add(Data.Subscribe(subject));

            _running = true;
            _timer = new Thread(TimerCallback);
            _timer.Start();
        }

        public void Stop()
        {
            _running = false;
            _timer?.Join();
            _timer = null;

            foreach (var disposable in disposables)
                disposable.Dispose();
            disposables.Clear();
        }

        private void TimerCallback()
        {
            while (_running)
            {
                _data.OnNext(ReadItem());
                Thread.Sleep(10);
            }
        }

        protected abstract T ReadItem();
    }
}
