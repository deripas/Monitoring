using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using SafeServer.dto;
using SafeServer.service.device;

namespace SafeServer.service
{
    public class AlertWriter
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        private IDisposable _disposable;
        
        public void Subscribe(ICollection<IDevice> devices)
        {
            _disposable = devices
                .OfType<IMeasureDevice>()
                .Select(device => device.Status())
                .Merge()
                .Where(status => status.version >= 0)
                .GroupBy(status => status.id)
                .SelectMany(group => group
                    .DistinctUntilChanged(status => status.alarm)
                    .Where(status => status.alarm > 0)
                    .Select(status => new Alert {device = group.Key, value = status.value, time = DateTime.Now, processed = false}))
                .ObserveOn(ThreadPoolScheduler.Instance)
                .Subscribe(WriteDB);
        }
        
        private void WriteDB(Alert alert)
        {
            Log.Warn("write alert {0}", alert.device);
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