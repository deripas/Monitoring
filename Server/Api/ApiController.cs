using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            return  db.Camera.OrderBy(c => c.Stand).ToList();
        }

        [HttpGet]
        [Route("camera/{id}")]
        public Camera CameraSingle(int id)
        {
            using var db = new DatabaseService();
            return db.Camera.Find(id);
        }

        [HttpGet]
        [Route("nvr")]
        public List<Nvr> Nvr()
        {
            using var db = new DatabaseService();
            return db.Nvr.ToList();
        }

        [HttpPost]
        [Route("alert")]
        public void AlertCreate(String device)
        {
            using var db = new DatabaseService();
            Alert alert = new Alert();
            alert.device = int.Parse(device);
            alert.time = DateTime.Now;
            alert.value = 0;
            db.Alert.Add(alert);
            db.SaveChanges();
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

        [HttpPut]
        [Route("alert/{id}/processed-all")]
        public void AlertProcessingAllBefore(long id)
        {
            using var db = new DatabaseService();
            var alert = db.Alert.Find(id);
            alert.processed = true;
            
            foreach( var a in db.Alert.Where(a => a.processed == false && a.time <= alert.time))
                a.processed = true;               
            db.SaveChanges();
        }

        [HttpGet]
        [Route("alert/{id}/find-before")]
        public object FindAlertAll(long id)
        {
            using var db = new DatabaseService();
            var alert = db.Alert.Find(id);
            int count = db.Alert.Count(a => a.processed == false && a.time <= alert.time);
            return new { count = count };
        }

        [HttpGet]
        [Route("alert/find-all")]
        public object FindAlertAll()
        {
            using var db = new DatabaseService();
            int count = db.Alert.Count(a => a.processed == false);
            return new { count = count };
        }

        [HttpGet]
        [Route("alert/find-last")]
        public Alert FindLastAlert(bool processed)
        {
            using var db = new DatabaseService();
            Alert alert = db.Alert
                .Where(a => a.processed == processed)
                .OrderByDescending(x => x.time)
                .FirstOrDefault();
            return alert ?? SafeServer.dto.Alert.NULL;
        }

        [HttpGet]
        [Route("device")]
        public List<Device> Device()
        {
            using var db = new DatabaseService();
            return db.Device.OrderBy(d => d.Stand).ThenBy(d => d.Type).ToList();
        }

        [HttpGet]
        [Route("device/{id}")]
        public Device DeviceSingle(long id)
        {
            using var db = new DatabaseService();
            return db.Device.Find(id);
        }

        [HttpGet]
        [Route("device/{id}/data")]
        public List<PointD> DeviceData(int id, String from, String to)
        {
            var f = DateTime.Parse(from, CultureInfo.InvariantCulture);
            var t = DateTime.Parse(to, CultureInfo.InvariantCulture);

            using var db = new DatabaseService();
            return db.SelectValues(id, f, t)
                .Select(v => new PointD { time = v.time.ToOADate(), value = v.val })
                .ToList();
        }

        [HttpPut]
        [Route("device/{id}/reset")]
        public void DeviceReset(int id)
        {
            var device = DI.Instance.DeviceService[id] as AlarmSensorDevice;
            device?.Reset();
        }
        
        [HttpPut]
        [Route("device/{id}/reset-alarm")]
        public void DeviceResetAlarm(int id)
        {
            var device = DI.Instance.DeviceService[id] as AlarmSensorDevice;
            device?.ResetAlarm();
        }
        
        [HttpPut]
        [Route("device/{id}/up")]
        public void RolletUp(int id)
        {
            var device = DI.Instance.DeviceService[id] as RolletDevice;
            device?.Up();
        }
        
        [HttpPut]
        [Route("device/{id}/down")]
        public void RolletDown(int id)
        {
            var device = DI.Instance.DeviceService[id] as RolletDevice;
            device?.Down();
        }

        [HttpPut]
        [Route("device/{id}/stop")]
        public void RolletStop(int id)
        {
            var device = DI.Instance.DeviceService[id] as RolletDevice;
            device?.Stop();
        }

        [HttpPut]
        [Route("device/{id}/on")]
        public void HurbleOn(int id)
        {
            var device = DI.Instance.DeviceService[id] as HurbleDevice;
            device?.PowerOn();
        }

        [HttpPut]
        [Route("device/{id}/off")]
        public void HurbleOff(int id)
        {
            var device = DI.Instance.DeviceService[id] as HurbleDevice;
            device?.PowerOff();
        }

        [HttpPut]
        [Route("device/{id}/auto")]
        public void HurbleAuto(int id)
        {
            var device = DI.Instance.DeviceService[id] as HurbleDevice;
            device?.PowerAuto();
        }

        [HttpPut]
        [Route("device/{id}/cfg")]
        public void DeviceConfig(long id, Config cfg)
        {
            var device = DI.Instance.DeviceService[id];

            using var db = new DatabaseService();
            var entity = db.Device.Find(id);
            var old = entity.Config;
            if (cfg.calibr != null)
                old.calibr = cfg.calibr;
            if (cfg.alarm != null)
                old.alarm = cfg.alarm;
            if (cfg.counter != null)
                old.counter = cfg.counter;
            if (cfg.simple != null)
            {
                entity.Removed = !cfg.simple.enable;
                entity.Description = cfg.simple.description;
            }
            entity.Version++;

            device.Update(cfg);
            device.Version = entity.Version;
            db.SaveChanges();
        }

        [HttpGet]
        [Route("status")]
        public List<DeviceStatus> Statuses()
        {
            return DI.Instance.DeviceStatusService.GetStatuses()
                .Values
                .OrderBy(s => s.id)
                .Select(s =>
                {
                    var dev = DI.Instance.DeviceService[s.id];
                    // uddate, get actual state
                    s.enable = dev.IsEnable();
                    s.version = dev.Version;
                    return s;
                })
                .ToList();
        }

        [HttpPut]
        [Route("stand/{stand}/{mode}/{id}")]
        public void ChangeMode(string stand, string mode, Guid id)
        {
            DI.Instance.ClientModeServise.ChangeMode(id, stand, mode);
        }
    }
}