using System.Collections.Generic;
using System.Net;

namespace api.dto
{
    public class NvrInfo
    {
        public int id { get; set; }
        public string ip { get; set; }
        public ushort port { get; set; }
        public string login { get; set; }
        public string password { get; set; }

        public IPEndPoint GetAddress()
        {
            return new IPEndPoint(IPAddress.Parse(ip), port);
        }
    }
}
