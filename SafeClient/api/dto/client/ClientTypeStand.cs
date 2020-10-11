using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace api.dto.client
{
    public class ClientTypeStand : ClientType
    {
        private string stand;
        private List<int> control;

        public ClientTypeStand(string stand)
        {
            this.stand = stand;

            control = service.DI.Instance.DeviceService.DeviceList
                .Where(device => device.Type.IsControll())
                .Where(device => stand.Equals(device.Stand))
                .OrderBy(device => device.Type)
                .ThenBy(device => device.Description)
                .Select(device => device.Id)
                .ToList();
        }

        public CameraGrid[] GetMode()
        {
            return new CameraGrid[] { ViewGrid(), ModeExperiment(), ModeOry(), ModeSleep() };
        }

        private CameraGrid ViewGrid()
        {
            var dev = service.DI.Instance.DeviceService.DeviceList
                .Where(device => device.Type.IsSensor())
                .Where(device => device.Type == DeviceType.water || device.Type == DeviceType.smoke)
                .OrderBy(device => device.Type)
                .ThenBy(device => device.Stand)
                .ThenBy(device => device.Description)
                .Select(device => device.Id)
                .ToList();

            return new CameraGrid()
            {
                cols = 6,
                rows = 6,
                cams = Camera(0),
                device = dev,
                control = control,
                stream = 1
            };
        }

        private CameraGrid ModeExperiment()
        {
            var dev = service.DI.Instance.DeviceService.DeviceList
                .Where(device => device.Type.IsSensor())
                .Where(device => stand.Equals(device.Stand) || ("ory".Equals(device.Stand) && device.Type == DeviceType.water))
                .OrderBy(device => device.Type)
                .ThenBy(device => device.Stand)
                .ThenBy(device => device.Description)
                .Select(device => device.Id)
                .ToList();

            return new CameraGrid()
            {
                cols = 3,
                rows = 3,
                cams = Camera(1),
                device = dev,
                control = control,
                stream = 0
            };
        }

        private CameraGrid ModeOry()
        {
            var dev = service.DI.Instance.DeviceService.DeviceList
                .Where(device => device.Type.IsSensor())
                .Where(device => stand.Equals(device.Stand) || "ory".Equals(device.Stand))
                .OrderBy(device => device.Type)
                .ThenBy(device => device.Stand)
                .ThenBy(device => device.Description)
                .Select(device => device.Id)
                .ToList();

            return new CameraGrid()
            {
                cols = 3,
                rows = 3,
                cams = Camera(2),
                device = dev,
                control = control,
                stream = 0
            };
        }

        private CameraGrid ModeSleep()
        {
            var dev = service.DI.Instance.DeviceService.DeviceList
                .Where(device => device.Type.IsSensor())
                .Where(device => stand.Equals(device.Stand) || ("ory".Equals(device.Stand) && device.Type == DeviceType.water))
                .OrderBy(device => device.Type)
                .ThenBy(device => device.Stand)
                .ThenBy(device => device.Description)
                .Select(device => device.Id)
                .ToList();

            return new CameraGrid()
            {
                cols = 3,
                rows = 3,
                cams = Camera(3),
                device = dev,
                control = control,
                stream = 0
            };
        }

        private List<int> Camera(int mode)
        {
            var cams = ConfigurationManager.AppSettings["client.type." + stand + "." + mode];
            return cams.Split(',').Select(int.Parse).ToList();
        }

        public string GetTitle()
        {
            return ConfigurationManager.AppSettings["client.type." + stand + ".label"];
        }

        string ClientType.GetType()
        {
            return stand;
        }
    }
}
