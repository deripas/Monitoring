using System;
using System.Collections.Generic;
using System.Text;

namespace SafeServer.dto
{
    public class CameraInfo
    {
        public long Id { get; set; }
        public string Ip { get; set; }
        public ushort Port { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Chanel { get; set; }

        public CameraInfo()
        {
        }

        public CameraInfo(long id, string ip, ushort port, string login, string password, int chanel)
        {
            Id = id;
            Ip = ip;
            Port = port;
            Login = login;
            Password = password;
            Chanel = chanel;
        }
    }
}
