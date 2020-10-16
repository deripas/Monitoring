namespace api.dto
{
    public class SensorStatus
    {
        public int id { get; set; }
        public bool enable { get; set; }
        public double value { get; set; }
        public long alarm { get; set; }
    }
}