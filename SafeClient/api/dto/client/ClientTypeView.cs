using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace api.dto.client
{
    public class ClientTypeView : ClientType
    {
        public CameraGrid[] GetMode()
        {
            return new CameraGrid[] { ViewGrid() };
        }

        private CameraGrid ViewGrid()
        {
            var cams = ConfigurationManager.AppSettings["client.type.view.0"];
            var devices = service.DI.Instance.DeviceService.DeviceList;
            var dev = devices
                .Where(device => device.Type.IsSensor())
                .OrderBy(device => device.Type)
                .ThenBy(device => device.Stand)
                .ThenBy(device => device.Description)
                .Select(device => device.Id)
                .ToList();

            return new CameraGrid()
            {
                cols = 6,
                rows = 6,
                cams = cams.Split(',').Select(int.Parse).ToList(),
                device = dev,
                control = new List<int> { },
                stream = 1
            };
        }

        public string GetTitle()
        {
            return ConfigurationManager.AppSettings["client.type.view.label"];
        }

        string ClientType.GetType()
        {
            return "view";
        }
    }
}
