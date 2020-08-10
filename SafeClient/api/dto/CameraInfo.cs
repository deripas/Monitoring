namespace api.dto
{
    public class CameraInfo
    {
        public long id { get; set; }
        public string name { get; set; }
        public double rate { get; set; }
        public double ratio { get; set; }
        public int nvr { get; set; }
        public int channel { get; set; }
        public bool enable { get; set; }
    }
}
