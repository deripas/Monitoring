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
                var cam = DI.Instance.CameraService[info.camera];
                result.Add(new AlertModel(cam, info));
            }
            result.Sort((x, y) => DateTime.Compare(x.Time, y.Time));
            return result;
        }

        internal ChartModel Chart(AlertModel alert, DateTime from, DateTime to)
        {
            int n = 1000;
            DateTime[] x = new DateTime[n];
            double[] y = new double[n];
            double millis = (to - from).TotalMilliseconds / n;
            for (int i = 0; i < n; i++)
            {
                x[i] = from.AddMilliseconds(i * millis);
                y[i] = Math.Sin((double)i * Math.PI * 2 / n);
            }

            var chart = new ChartModel();
            chart.X = x;
            chart.Y = y;
            chart.From = from;
            chart.To = to;
            chart.Alert = alert.Time;
            return chart;
        }
    }
}
