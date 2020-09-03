using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using SafeServer.dto;
using SafeServer.service.device;

namespace SafeServer.service
{
    public class MeasureWriter
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        private IDisposable _disposable;
        
        public void Subscribe(ICollection<IDevice> devices)
        {
            _disposable = devices
                .OfType<IMeasureDevice>()
                .Select(device => device.Status())
                .Merge()
                .Buffer(TimeSpan.FromSeconds(1))
                .Select(ToBatch)
                .ObserveOn(ThreadPoolScheduler.Instance)
                .Subscribe(WriteDB);
        }

        private IList<Value> ToBatch(IList<DeviceStatus> statuses)
        {
            var dic = new Dictionary<long, DeviceStatus>();
            foreach (var s in statuses)
                dic[s.id] = s;
            
            return dic.Values
                .Select(s => new Value {device = s.id, val = s.value, time = DateTime.Now})
                .ToList();
        }
        
        private void WriteDB(IList<Value> values)
        {
            Log.Trace("write values {0}", values.Count);
            using var db = new DatabaseService();
            db.InsertValues(values);
        }
        
        internal void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}