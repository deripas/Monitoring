namespace api.dto
{
    public class SensorStatus
    {
        public int id { get; set; }
        public long version { get; set; }
        public bool enable { get; set; }
        public bool reset { get; set; }
        public double value { get; set; }
        public bool alarm { get; set; }
        public bool up { get; set; }
        public bool dw { get; set; }
    }
}