using api.dto;
using System;
using System.Collections.Generic;

namespace api.impl
{
    public class MockServerApi : IServerApi
    {
        public List<AlertInfo> Alerts(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public List<CameraInfo> Camera()
        {
            throw new NotImplementedException();
            /*
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
            };*/
        }

        public List<NvrInfo> Nvr()
        {
            throw new NotImplementedException();
        }
    }
}
