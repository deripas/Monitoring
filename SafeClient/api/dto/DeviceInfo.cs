using System;

namespace api.dto
{
    public class DeviceInfo
    {

        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool enable { get; set; }
        public int? camera { get; set; }
        public string type { get; set; }

        public DeviceType GetTypeEnum()
        {
            DeviceType tryType;
            if (Enum.TryParse<DeviceType>(type, out tryType))
                return tryType;
            else
                return DeviceType.unknown;
        }
    }
}
