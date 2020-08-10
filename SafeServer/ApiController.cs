using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafeServer.dto;
using SafeServer.service;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SafeServer
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
            using (var db = new DatabaseService())
            {
                return  db.Camera.ToList();
            }
        }

        [HttpGet]
        [Route("nvr")]
        public List<Nvr> Nvr()
        {
            using (var db = new DatabaseService())
            {
                return db.Nvr.ToList();
            }
        }

        [HttpGet]
        [Route("alert")]
        public List<Alert> Alert(String from, String to)
        {
            DateTime f = DateTime.Parse(from, CultureInfo.InvariantCulture);
            DateTime t = DateTime.Parse(to, CultureInfo.InvariantCulture);
            using (var db = new DatabaseService())
            {
                return db.Alert.Where(x => f <= x.time && x.time <= t).ToList();
            }
        }
    }
}
