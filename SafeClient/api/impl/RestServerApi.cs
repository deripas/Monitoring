using api.dto;
using Spring.Http.Converters.Json;
using Spring.Rest.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;

namespace api.impl
{
    public class RestServerApi : IServerApi
    {
        private RestTemplate template;

        public RestServerApi()
        {
            template = new RestTemplate(ConfigurationManager.AppSettings["server.url"]);
            template.MessageConverters.Add(new DataContractJsonHttpMessageConverter());
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
    }
}
