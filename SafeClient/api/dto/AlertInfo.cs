using System;

namespace api.dto
{
    public class AlertInfo
    {
        public long id { get; set; }
        public int camera { get; set; }
        public int device { get; set; }
        public String time { get; set; }
        public double value { get; set; }
        public bool processed { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(time);
        }
    }
}
