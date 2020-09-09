using api.dto;
using Spring.Http.Client;
using Spring.Http.Converters.Json;
using Spring.Rest.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Windows.Forms;

namespace api.impl
{
    public class RestServerApi : IServerApi
    {
        private RestTemplate template;

        public RestServerApi()
        {
            var factory = new WebClientHttpRequestFactory();
            factory.Timeout = 3000;

            template = new RestTemplate(ConfigurationManager.AppSettings["server.url"]);
            template.MessageConverters.Add(new DataContractJsonHttpMessageConverter());
            template.RequestFactory = factory;
        }

        public List<NvrInfo> Nvr()
        {
            return template.GetForObject<List<NvrInfo>>("/api/nvr");
        }

        public List<CameraInfo> Camera()
        {
            return template.GetForObject<List<CameraInfo>>("/api/camera");
        }

        public List<DeviceInfo> Device()
        {
            return template.GetForObject<List<DeviceInfo>>("/api/device");
        }

        public DeviceInfo DeviceSingle(int id)
        {
            return template.GetForObject<DeviceInfo>("/api/device/{id}", id);
        }

        public void DeviceConfig(int device, Config cfg)
        {
            template.Put("/api/device/{id}/cfg", cfg, device);
        }

        public List<AlertInfo> Alerts(DateTime from, DateTime to)
        {
            var uri = string.Format("/api/alert?from={0}&to={1}", from.ToString(CultureInfo.InvariantCulture), to.ToString(CultureInfo.InvariantCulture));
            return template.GetForObject<List<AlertInfo>>(uri);
        }

        public List<AlertInfo> Alerts(int device, DateTime from, DateTime to)
        {
            var uri = string.Format("/api/alert?from={0}&to={1}&device={2}", from.ToString(CultureInfo.InvariantCulture), to.ToString(CultureInfo.InvariantCulture), device);
            return template.GetForObject<List<AlertInfo>>(uri);
        }

        public List<PointD> DeviceData(int device, DateTime from, DateTime to)
        {
            var uri = string.Format("/api/device/{2}/data?from={0}&to={1}", from.ToString(CultureInfo.InvariantCulture), to.ToString(CultureInfo.InvariantCulture), device);
            return template.GetForObject<List<PointD>>(uri);
        }

        public List<SensorStatus> Statuses()
        {
            return template.GetForObject<List<SensorStatus>>("/api/status");
        }

        public void RolletUp(int device)
        {
            tryAction(() => template.Put("/api/device/{id}/up", null, device ));
        }

        public void RolletDown(int device)
        {
            tryAction(() => template.Put("/api/device/{id}/down", null, device ));
        }

        public void RolletStop(int device)
        {
            tryAction(() => template.Put("/api/device/{id}/stop", null, device));
        }

        public void HurbleOn(int device)
        {
            tryAction(() => template.Put("/api/device/{id}/on", null, device));
        }

        public void HurbleOff(int device)
        {
            tryAction(() => template.Put("/api/device/{id}/off", null, device));
        }

        public void HurbleAuto(int device)
        {
            tryAction(() => template.Put("/api/device/{id}/auto", null, device));
        }

        public void ProcessAlert(long id)
        {
            tryAction(() => template.Put("/api/alert/{id}/processed", null, id));
        }

        public void ProcessAlertAll(long id)
        {
            tryAction(() => template.Put("/api/alert/{id}/processed-all", null, id));
        }

        public CountResult FindAlertAll(long id)
        {
            return template.GetForObject<CountResult>("/api/alert/{id}/find-before", id);
        }

        public CountResult FindAlertAll()
        {
            return template.GetForObject<CountResult>("/api/alert/find-all");
        }

        public AlertInfo FindLastAlert(bool processed)
        {
            var uri = string.Format("/api/alert/find-last?processed={0}", processed);
            return template.GetForObject<AlertInfo>(uri);
        }

        public void ResetDevice(long device)
        {
            tryAction(() => template.Put("/api/device/{id}/reset", null, device ));
        }
        
        public void ResetDeviceAlert(long device)
        {
            tryAction(() => template.Put("/api/device/{id}/reset-alarm", null, device));
        }

        private void tryAction(Action a)
        {
            try
            {
                a.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
