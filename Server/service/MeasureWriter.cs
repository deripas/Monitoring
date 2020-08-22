using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using SafeServer.dto;

namespace SafeServer.service
{
    public class MeasureWriter
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        private IDisposable _disposable;
        
        public void Subscribe(IObservable<SensorStatus> observable)
        {
            _disposable = observable
                .Where(status => status.value.HasValue && !double.IsNaN(status.value.Value))
                .Buffer(TimeSpan.FromSeconds(1))
                .Select(ToBatch)
                .ObserveOn(ThreadPoolScheduler.Instance)
                .Subscribe(WriteDB);
        }

        private void WriteDB(IList<Value> values)
        {
            Log.Debug("write values {0}", values.Count);
            using var db = new DatabaseService();
            db.InsertValues(values);
        }

        internal void Dispose()
        {
            _disposable?.Dispose();
        }

        private IList<Value> ToBatch(IList<SensorStatus> statuses)
        {
            var dic = new Dictionary<long, SensorStatus>();
            foreach (var s in statuses)
                dic[s.id] = s;
            return dic.Values
                .Select(s => new Value {device = s.id, val = s.value.Value, time = DateTime.Now})
                .ToList();
        }
    }
}