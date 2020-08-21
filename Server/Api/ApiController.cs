using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SafeServer;
using SafeServer.dto;
using SafeServer.service;

namespace Server.Api
{
  [ApiController]
    [Route("/api")]
    [Produces("application/json")]
    public class ApiController : ControllerBase
    {
        [HttpGet]
        [Route("camera")]
        public List<Camera> Camera()
        {
            using var db = new DatabaseService();
            return  db.Camera.ToList();
        }

        [HttpGet]
        [Route("nvr")]
        public List<Nvr> Nvr()
        {
            using var db = new DatabaseService();
            return db.Nvr.ToList();
        }

        [HttpGet]
        [Route("alert")]
        public List<Alert> Alert(String device, String from, String to)
        {
            if (from != null && to != null)
            {
                DateTime f = DateTime.Parse(from, CultureInfo.InvariantCulture);
                DateTime t = DateTime.Parse(to, CultureInfo.InvariantCulture);

                if (device == null)
                {
                    using (var db = new DatabaseService())
                    {
                        return db.Alert.Where(x => f <= x.time && x.time <= t)
                            .OrderByDescending(x => x.time)
                            .ToList();
                    }
                }
                else
                {
                    int id = int.Parse(device);
                    using (var db = new DatabaseService())
                    {
                        return db.Alert.Where(x => f <= x.time && x.time <= t && x.device == id)
                            .OrderByDescending(x => x.time)
                            .ToList();
                    }
                }
            }
            return null;
        }

        [HttpGet]
        [Route("device")]
        public List<Device> Device()
        {
            using var db = new DatabaseService();
            return db.Device.ToList();
        }

        [HttpGet]
        [Route("device/{id}/data")]
        public List<PointD> DeviceData(int id, String from, String to)
        {
            DateTime f = DateTime.Parse(from, CultureInfo.InvariantCulture);
            DateTime t = DateTime.Parse(to, CultureInfo.InvariantCulture);
            using var db = new DatabaseService();
            return db.SelectValues(id, f, t)
                .Select(v => new PointD { time = v.time.ToOADate(), value = v.val })
                .ToList();
        }

        [HttpGet]
        [Route("device/{id}/generate")]
        public List<PointD> DeviceDataGenerate(int id, String from, String to)
        {
            var random = new Random();
            DateTime f = DateTime.Parse(from, CultureInfo.InvariantCulture);
            DateTime t = DateTime.Parse(to, CultureInfo.InvariantCulture);
            List<Value> v = new List<Value>();

            for (DateTime x = f; x < t; x = x.AddSeconds(1))
                v.Add(new Value() { device = id, time = x, val = random.NextDouble() * 100.0 });

            using var db = new DatabaseService();
            db.InsertValues(v);
            return v
                    .Select(v => new PointD { time = v.time.ToOADate(), value = v.val })
                    .ToList();
        }
        
        [HttpPost]
        [Route("device/{id}/reset")]
        public void DeviceReset(int id)
        {
            DI.Instance.DeviceService[id].Reset();
        }

        [HttpGet]
        [Route("status")]
        public List<SensorStatus> Statuses()
        {
            return DI.Instance.DeviceService.GetAllStatus();
        }
    }
}