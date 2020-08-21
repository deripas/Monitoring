using SafeServer.dto.config;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeServer.dto
{
    public class Config
    {
        public Channel sensor { get; set; }
        public Channel power { get; set; }
        public Alarm alarm { get; set; }
        public long siren{ get; set; }
    }
}
