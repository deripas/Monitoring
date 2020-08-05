using System;

namespace api.dto
{
    public class AlertInfo
    {
        public long CameraId { get; set; }
        public long DeviceId { get; set; }
        public DateTime Time { get; set; }
        public double Value { get; set; }

        public AlertInfo()
        {
        }

        public AlertInfo(long cameraId, long deviceId, DateTime time, double value)
        {
            CameraId = cameraId;
            DeviceId = deviceId;
            Time = time;
            Value = value;
        }
    }
}
