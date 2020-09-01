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

        [HttpGet]
        [Route("status")]
        public List<DeviceStatus> Statuses()
        {
            return DI.Instance.DeviceStatusService.GetStatuses()
                .Values
                .ToList();
        }
    }
}