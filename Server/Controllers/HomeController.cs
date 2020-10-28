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
            MyModel model = new MyModel();
            return View("Camera", model);
        }

        public IActionResult CameraStand(string stand)
        {
            MyModel model = new MyModel
            {
                stand = stand
            };
            return View("Camera", model);
        }

        public IActionResult Device()
        {
            MyModel model = new MyModel();
            return View("Device", model);
        }

        public IActionResult DeviceStand(string stand)
        {
            MyModel model = new MyModel
            {
                stand = stand
            };
            return View("Device", model);
        }

        public IActionResult CameraTable(string? stand)
        {
            var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
            using var db = new DatabaseService();
            var camera = db.Camera
                .Where(c => stand == null || c.Stand.Equals(stand))
                .OrderBy(c => c.Name)
                .ToList()
                .Select(c =>
                {
                    return new
                    {
                        name = c.Name,
                        main = c.rtsp + "0",
                        sub = c.rtsp + "1"
                    };
                })
                .ToList();
            return Json(new
            {
                draw = draw,
                recordsFiltered = camera.Count,
                recordsTotal = camera.Count,
                data = camera
            });
        }

        public IActionResult DeviceTable(string? stand)
        {
            Dictionary<long, DeviceStatus> status = DI.Instance.DeviceStatusService.GetStatuses();
            var draw = HttpContext.Request.Form["draw"].FirstOrDefault();

            using var db = new DatabaseService();
            var devices = db.Device
                .Where(c => stand == null || c.Stand.Equals(stand))
                .OrderBy(c => c.Name)
                .ToList();
            var result = new List<object>();
            foreach (var dev in devices)
            {
                var camId = dev.Camera;
                if (!camId.HasValue) continue;

                var cam = DI.Instance.CameraService[camId.Value];
                DeviceStatus s;
                var exist = status.TryGetValue(dev.Id, out s);
                result.Add(new
                {
                    id = dev.Id,
                    name = dev.Name,
                    alert = s != null && s.alarm > 0,
                    enable = dev.Enable && !dev.Removed,
                    main = cam.rtsp + "0",
                    sub = cam.rtsp + "1",
                    value = exist ? DI.Instance.DeviceService[dev.Id].RenderStatusValue(s) : "-"
                });
            }
            return Json(new { draw = draw, recordsFiltered = result.Count, recordsTotal = result.Count, data = result });
        }
    }
}