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
        
        public Channel motorUP { get; set; }
        public Channel motorDW { get; set; }
        
        public Channel sensorUP { get; set; }
        public Channel sensorDW { get; set; }
        public Alarm alarm { get; set; }
        public long siren{ get; set; }
        
        public  double porog{ get; set; }
        public  double min{ get; set; }
        public  double max{ get; set; }
    }
}
