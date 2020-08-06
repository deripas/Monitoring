using api;
using api.dto;
using model.device;
using System;
using System.Collections.Generic;

namespace service
{
    public class DeviceService
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        private IServerApi serverApi;

        public DeviceService(IServerApi serverApi)
        {
            this.serverApi = serverApi;
        }

        internal void Dispose()
        {
            
        }

        internal List<AlertModel> FindAlerts(DateTime value)
        {
            Log.Info("search alert {0}", value);
            List<AlertModel> result = new List<AlertModel>();
            var alerts = serverApi.Alerts(value.Date, value.Date.AddDays(1));
            foreach (AlertInfo info in alerts)
            {
                var cam = DI.Instance.CameraService[info.CameraId];
                result.Add(new AlertModel(cam, info));
            }
            result.Sort((x, y) => DateTime.Compare(x.Time, y.Time));
            return result;
        }
    }
}
