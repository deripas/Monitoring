using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SafeServer.dto
{
    public class NvrInfo
    {
        public string Ip { get; }
        public ushort Port { get; }
        public string Login { get; }
        public string Password { get; }

        public NvrInfo(string ip, ushort port, string login, string password)
        {
            Ip = ip;
            Port = port;
            Login = login;
            Password = password;
        }

        public override bool Equals(object obj)
        {
            return obj is NvrInfo nvr &&
                   Ip == nvr.Ip &&
                   Port == nvr.Port &&
                   Login == nvr.Login &&
                   Password == nvr.Password;
        }

        public override int GetHashCode()
        {
            var hashCode = 1961031324;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Ip);
            hashCode = hashCode * -1521134295 + Port.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Login);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Password);
            return hashCode;
        }

        public IPEndPoint GetAddress()
        {
            var ip = IPAddress.Parse(Ip);
            return new IPEndPoint(ip, Port);
        }
    }
}
