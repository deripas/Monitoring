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
        public CameraController Camera;
        private AlertInfo info;

        public AlertModel(CameraController camera, AlertInfo info)
        {
            this.Camera = camera;
            this.info = info;
        }

        public override string ToString()
        {
            return String.Format("alert [{0:HH:mm:ss}]", Time);
        }

        internal VideoTimeRangeModel Video(DateTime from, DateTime to)
        {
            return Camera.SearchVideo(from, to);
        }
    }
}
