using SafeServer.dto.config;

namespace SafeServer.dto
{
    public class Config
    {
        public long timeout { get; set; }
        public Channel sensor { get; set; }
        public Channel power { get; set; }

        public Channel motorUP { get; set; }
        public Channel motorDW { get; set; }

        public Channel sensorUP { get; set; }
        public Channel sensorDW { get; set; }
        public Alarm alarm { get; set; }
        public Channel siren { get; set; }

        public double porogMax { get; set; }
        public double porogMin { get; set; }
        public double min { get; set; }
        public double max { get; set; }
    }
}