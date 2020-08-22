using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SafeServer;
using SafeServer.dto;
using SafeServer.service;
using SafeServer.service.device;

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
                    using var db = new DatabaseService();
                    return db.Alert
                        .Where(x => f <= x.time && x.time <= t)
                        .OrderByDescending(x => x.time)
                        .ToList();
                }
                else
                {
                    int id = int.Parse(device);
                    using var db = new DatabaseService();
                    return db.Alert
                        .Where(x => f <= x.time && x.time <= t && x.device == id)
                        .OrderByDescending(x => x.time)
                        .ToList();
                }
            }
            return null;
        }

        [HttpPut]
        [Route("alert/{id}/processed")]
        public void AlertProcessing(long id)
        {
            using var db = new DatabaseService();
            var alert = db.Alert.Find(id);
            alert.processed = true;
            db.SaveChanges();
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
            var f = DateTime.Parse(from, CultureInfo.InvariantCulture);
            var t = DateTime.Parse(to, CultureInfo.InvariantCulture);

            // using var db = new DatabaseService();
            // return db.SelectValues(id, f, t)
            //     .Select(v => new PointD { time = v.time.ToOADate(), value = v.val })
            //     .ToList();
            
            var random = new Random();
            var v = new List<Value>();

            for (DateTime x = f; x < t; x = x.AddSeconds(1))
                v.Add(new Value() { device = id, time = x, val = random.NextDouble() * 100.0 });
            return v
                .Select(v => new PointD { time = v.time.ToOADate(), value = v.val })
                .ToList();
        }

        [HttpGet]
        [Route("device/{id}/generate")]
        public List<PointD> DeviceDataGenerate(int id, String from, String to)
        {
            var f = DateTime.Parse(from, CultureInfo.InvariantCulture);
            var t = DateTime.Parse(to, CultureInfo.InvariantCulture);
            var random = new Random();
            var v = new List<Value>();

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
        
        [HttpPut]
        [Route("device/{id}/up")]
        public void RolletUp(int id)
        {
            var device = DI.Instance.DeviceService[id] as RolletDev;
            device?.Up();
        }
        
        [HttpPut]
        [Route("device/{id}/down")]
        public void RolletDown(int id)
        {
            var device = DI.Instance.DeviceService[id] as RolletDev;
            device?.Down();
        }

        [HttpGet]
        [Route("status")]
        public List<SensorStatus> Statuses()
        {
            return DI.Instance.DeviceService.GetAllStatus();
        }
    }
}