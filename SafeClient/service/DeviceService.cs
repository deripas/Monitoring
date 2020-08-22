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
        private Dictionary<int, DeviceController> _deviceMapById;

        public List<DeviceController> DeviceList { get; }

        public DeviceController this[int id]
        {
            get
            {
                return _deviceMapById[id];
            }
        }
        public DeviceService(IServerApi serverApi)
        {
            this.serverApi = serverApi;
            _deviceMapById = new Dictionary<int, DeviceController>();
            DeviceList = new List<DeviceController>();
            foreach (DeviceInfo info in serverApi.Device())
            {
                var dev = new DeviceController(info);
                _deviceMapById.Add(info.id, dev);
                DeviceList.Add(dev);
            }
        }

        internal void Dispose()
        {
            
        }

        internal List<AlertModel> FindAlerts(DateTime from, DateTime to)
        {
            return ToAlertModel(serverApi.Alerts(from, to));
        }

        internal List<AlertModel> FindAlerts(int device, DateTime from, DateTime to)
        {
            return ToAlertModel(serverApi.Alerts(device, from, to));
        }

        private List<AlertModel> ToAlertModel(List<AlertInfo> alerts)
        {
            List<AlertModel> result = new List<AlertModel>();
            foreach (AlertInfo info in alerts)
            {
                var dev = DI.Instance.DeviceService[info.device];
                var cam = dev.Camera;
                if (cam == null)
                {
                    Log.Warn("[{0}] Ignored! Without camera!", info);
                    continue;
                }
                result.Add(new AlertModel(cam, dev, info));
            }
            return result;
        }

        internal ChartModel Chart(AlertModel alert, DateTime from, DateTime to)
        {
            var points = serverApi.DeviceData(alert.Device.Id, from, to);
            var x = new List<DateTime>();
            var y = new List<double>();

            foreach(PointD p in points)
            {
                x.Add(DateTime.FromOADate(p.time));
                y.Add(p.value);
            }

            var chart = new ChartModel();
            chart.X = x;
            chart.Y = y;
            chart.From = from;
            chart.To = to;
            chart.Alert = alert.Time;
            return chart;
        }

        public void RolletUp(int device)
        {
            serverApi.RolletUp(device);
        }

        public void RolletDown(int device)
        {
            serverApi.RolletDown(device);
        }
    }
}
