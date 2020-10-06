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
                .Where(status => status.alarm >= 0 && status.version >= 0)
                .Buffer(TimeSpan.FromSeconds(1))
                .Select(ToBatch)
                .ObserveOn(ThreadPoolScheduler.Instance)
                .Subscribe(WriteDB);
        }

        private IList<Value> ToBatch(IList<DeviceStatus> statuses)
        {
            var dic = new Dictionary<long, Value>();
            foreach (var s in statuses)
            {
                var val = dic.ContainsKey(s.id)
                    ? Math.Max(dic[s.id].val, s.value)
                    : s.value;
                dic[s.id] = new Value {device = s.id, val = val, time = DateTime.Now};
            }
            return dic.Values.ToList();
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