using SafeServer.dto.config;

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

        public Channel siren { get; set; }

        public Alarm alarm { get; set; }
        public Calibr calibr { get; set; }
    }
}