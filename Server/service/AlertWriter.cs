﻿using System;
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
                .Where(status => status.alarm > 0 && status.enable)
                .GroupBy(status => status.id)
                .SelectMany(group => group
                    .DistinctUntilChanged(status => status.alarm)
                    .Select(status => new Alert {device = group.Key, value = status.value, time = DateTime.Now, processed = false}))
                .ObserveOn(ThreadPoolScheduler.Instance)
                .Subscribe(WriteDB);
        }
        
        private void WriteDB(Alert alert)
        {
            var dev = DI.Instance.DeviceService[alert.device];
            Log.Warn("write alert \"{0}\" ({1})", dev.Name, dev.Id);
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