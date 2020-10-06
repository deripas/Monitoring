using SafeServer.dto.config;
using Server.dto.config;

namespace SafeServer.dto
{
    public class Config
    {
        public Channel sensor { get; set; } //41,27
        public Channel power { get; set; } //42

        public Channel encoder { get; set; } //41
        public Channel remote { get; set; } //41

        public Channel motorUP { get; set; } //42
        public Channel motorDW { get; set; } //42

        public Channel sensorUP { get; set; } //41
        public Channel sensorDW { get; set; } //41
        public Channel sensorX { get; set; } //25
        public Channel sensorY { get; set; } //25

        public Channel siren { get; set; } //42

        public Base simple { get; set; }
        public Alarm alarm { get; set; }
        public Calibr calibr { get; set; }
        public Encoder counter { get; set; }
    }
}