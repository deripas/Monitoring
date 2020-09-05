using SafeServer.dto.config;

namespace api.dto
{
    public class Config
    {
        public Base simple { get; set; }
        public Alarm alarm { get; set; }
        public Calibr calibr { get; set; }
        public Encoder counter { get; set; }
    }
}