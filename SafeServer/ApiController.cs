using Microsoft.AspNetCore.Mvc;
using SafeServer.dto;
using System.Collections.Generic;

namespace SafeServer
{
    [ApiController]
    [Route("/api")]
    public class ApiController : ControllerBase
    {
        private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        /*
        [HttpGet]
        public IActionResult Get()
        {
            log.Info("[test] get");
            var name = "?";
            var greeting = "Hello " + name;
            return new JsonResult(new string[] { name, greeting });
        }*/

        [HttpGet]
        public string[] Get()
        {
            log.Info("[test] get");
            var name = "?";
            var greeting = "Hello " + name;
            return new string[] { name, greeting };
        }

        [HttpPost]
        public IActionResult Post([FromBody] string name)
        {
            return new NoContentResult();
        }

        [HttpGet]
        [Route("camera")]
        public List<CameraInfo> Cameras()
        {
            const string login = "admin";
            const string pwd = "1qaz2wsx";
            var i = 0;

            if (false)
            {
                return new List<CameraInfo>
                {
                    new CameraInfo(i++, "192.168.1.99", 34567, login, pwd, 0),
                    new CameraInfo(i++, "192.168.1.99", 34567, login, pwd, 1),
                    new CameraInfo(i++, "192.168.1.99", 34567, login, pwd, 2),
                    new CameraInfo(i++, "192.168.1.99", 34567, login, pwd, 3),
                    new CameraInfo(i++, "192.168.1.99", 34567, login, pwd, 3),
                    new CameraInfo(i++, "192.168.1.99", 34567, login, pwd, 3),
                };
            }
            return new List<CameraInfo>
            {
                new CameraInfo(i++, "192.168.1.241", 34567, login, pwd, 0),
                new CameraInfo(i++, "192.168.1.241", 34567, login, pwd, 1),
                new CameraInfo(i++, "192.168.1.241", 34567, login, pwd, 2),
                new CameraInfo(i++, "192.168.1.241", 34567, login, pwd, 3),

                new CameraInfo(i++, "192.168.1.242", 34567, login, pwd, 0),
                new CameraInfo(i++, "192.168.1.242", 34567, login, pwd, 1),
                new CameraInfo(i++, "192.168.1.242", 34567, login, pwd, 2),
                new CameraInfo(i++, "192.168.1.242", 34567, login, pwd, 3),

                new CameraInfo(i++, "192.168.1.243", 34567, login, pwd, 0),
                new CameraInfo(i++, "192.168.1.243", 34567, login, pwd, 1),
                new CameraInfo(i++, "192.168.1.243", 34567, login, pwd, 2),
                new CameraInfo(i++, "192.168.1.243", 34567, login, pwd, 3),

                new CameraInfo(i++, "192.168.1.244", 34567, login, pwd, 0),
                new CameraInfo(i++, "192.168.1.244", 34567, login, pwd, 1),
                new CameraInfo(i++, "192.168.1.244", 34567, login, pwd, 2),
                new CameraInfo(i++, "192.168.1.244", 34567, login, pwd, 3),

                new CameraInfo(i++, "192.168.1.241", 34567, login, pwd, 4),
                new CameraInfo(i++, "192.168.1.241", 34567, login, pwd, 5),
                new CameraInfo(i++, "192.168.1.241", 34567, login, pwd, 6),
                new CameraInfo(i++, "192.168.1.241", 34567, login, pwd, 7),

                new CameraInfo(i++, "192.168.1.242", 34567, login, pwd, 4),
                new CameraInfo(i++, "192.168.1.242", 34567, login, pwd, 5),
                new CameraInfo(i++, "192.168.1.242", 34567, login, pwd, 6),
                new CameraInfo(i++, "192.168.1.242", 34567, login, pwd, 7),

                new CameraInfo(i++, "192.168.1.243", 34567, login, pwd, 4),
                new CameraInfo(i++, "192.168.1.243", 34567, login, pwd, 5),
                new CameraInfo(i++, "192.168.1.243", 34567, login, pwd, 6),
                new CameraInfo(i++, "192.168.1.243", 34567, login, pwd, 7),

                new CameraInfo(i++, "192.168.1.244", 34567, login, pwd, 4),
                new CameraInfo(i++, "192.168.1.244", 34567, login, pwd, 5),
                new CameraInfo(i++, "192.168.1.244", 34567, login, pwd, 6),
                new CameraInfo(i++, "192.168.1.244", 34567, login, pwd, 7),

                new CameraInfo(i++, "192.168.1.242", 34567, login, pwd, 9),
            };
        }
    }
}
