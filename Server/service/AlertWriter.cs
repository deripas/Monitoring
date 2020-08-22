using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using SafeServer.dto;

namespace SafeServer.service
{
    public class AlertWriter
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        private IDisposable _disposable;
        
        public void Subscribe(IObservable<SensorStatus> observable)
        {
            _disposable = observable
                .GroupBy(status => status.id)
                .SelectMany(group => group
                    .DistinctUntilChanged(status => status.alarm)
                    .Where(status => status.alarm)
                    .Select(status => new Alert {device = group.Key, value = status.value, time = DateTime.Now, processed = false}))
                .Subscribe(WriteDB);
        }
        
        private void WriteDB(Alert alert)
        {
            Log.Debug("write alert {0}", alert);
            using var db = new DatabaseService();
            db.Alert.Add(alert);
            db.SaveChanges();
        }
        
        internal void Dispose()
        {
            _disposable?.Dispose();
        }

    }
}