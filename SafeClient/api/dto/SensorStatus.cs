namespace api.dto
{
    public class SensorStatus
    {
        public int id { get; set; }
        public long version { get; set; }
        public double value { get; set; }
        public long alarm { get; set; }
    }
}