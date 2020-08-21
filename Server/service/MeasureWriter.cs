using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using SafeServer.dto;

namespace SafeServer.service
{
    public class MeasureWriter
    {
        private IDisposable _disposable;
        
        public void Subscribe(IObservable<SensorStatus> observable)
        {
            _disposable = observable
                .Buffer(TimeSpan.FromSeconds(1))
                .Select(ToBatch)
                .Subscribe();
        }
        internal void Dispose()
        {
            _disposable?.Dispose();
        }

        private List<Value> ToBatch(IList<SensorStatus> statuses)
        {
            return new List<Value>();
        }
    }
}