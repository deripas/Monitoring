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
            var camera = db.Camera.ToList()
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

        public IActionResult DeviceTable()
        {
            Dictionary<long, DeviceStatus> status = DI.Instance.DeviceStatusService.GetStatuses();
            var draw = HttpContext.Request.Form["draw"].FirstOrDefault();

            var devices =  DI.Instance.DeviceService.Devices;
            var result = new List<DeviceModel>();
            foreach (var dev in devices)
            {
                var camId = dev.CameraId();
                if (!camId.HasValue) continue;

                var cam = DI.Instance.CameraService[camId.Value];
                DeviceStatus s;
                var exist = status.TryGetValue(dev.Id(), out s);
                result.Add(new DeviceModel
                {
                    id = dev.Id(),
                    name = dev.Name(),
                    alert = s.alarm > 0,
                    rtsp = cam.rtsp + "1",
                    value = exist ? dev.RenderStatusValue(s) : "-"
                });
            }
            return Json(new { draw = draw, recordsFiltered = result.Count, recordsTotal = result.Count, data = result });
        }
    }
}