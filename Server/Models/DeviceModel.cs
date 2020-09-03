namespace Server.Models
{
    public class DeviceModel
    {
        public long id { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public bool alert { get; set; }
        public string rtsp { get; set; }
    }
}
