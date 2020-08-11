using api.dto;
using model.camera;
using model.video;
using System;
using SDK_HANDLE = System.Int32;

namespace model.device
{
    public class AlertModel
    {
        public DateTime Time
        {
            get
            {
                return info.GetDateTime();
            }
        }
        public bool Processed
        {
            get
            {
                return info.processed;
            }
        }

        public CameraController Camera;
        public DeviceController Device;
        private AlertInfo info;

        public AlertModel(CameraController camera, DeviceController device, AlertInfo info)
        {
            this.Camera = camera;
            this.Device = device;
            this.info = info;
        }

        public override string ToString()
        {
            return String.Format("[{0:HH:mm:ss}]", Time);
        }

        internal VideoTimeRangeModel Video(DateTime from, DateTime to)
        {
            return Camera.SearchVideo(from, to);
        }
    }
}
