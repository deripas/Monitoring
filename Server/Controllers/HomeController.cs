using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SafeServer;
using SafeServer.dto;
using SafeServer.service;
using Server.Models;

namespace Server.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Camera()
        {
            return View();
        }

        public IActionResult Device()
        {
            return View();
        }

        public IActionResult CameraTable()
        {
            var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
            using var db = new DatabaseService();
            var camera = db.Camera.ToList();
            return Json(new { draw = draw, recordsFiltered = camera.Count, recordsTotal = camera.Count, data = camera });
        }

        public IActionResult DeviceTable()
        {
            Dictionary<long, DeviceStatus> status = DI.Instance.DeviceStatusService.GetStatuses();
            var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
            using var db = new DatabaseService();
            var query = from d in db.Device 
                         join c in db.Camera on d.Camera equals c.Id
                         select new {d.Id, d.Name, c.rtsp };

            var result = new List<DeviceModel>();
            foreach (var item in query.ToList())
            {
                DeviceStatus s;
                var exist = status.TryGetValue(item.Id, out s);
                result.Add(new DeviceModel
                {
                    id = item.Id,
                    name = item.Name,
                    rtsp = item.rtsp,
                    value = exist ? s.value.ToString() : "-"
                });
            }
            return Json(new { draw = draw, recordsFiltered = result.Count, recordsTotal = result.Count, data = result });
        }
    }
}