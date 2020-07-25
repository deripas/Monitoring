using api;
using model.nvr;
using System;
using SDK_HANDLE = System.Int32;

namespace model.camera
{
    public class CameraModel
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        private NvrModel nvr;

        public int Channel { get; }

        public SDK_HANDLE LoginId
        {
            get
            {
                return nvr.LoginId;
            }
        }

        public bool Talk
        {
            get
            {
                return nvr.Talk;
            }
        }

        public CameraModel(NvrModel nvr, int channel)
        {
            this.nvr = nvr;
            this.Channel = channel;
        }

        internal void StartTalk()
        {
            nvr.StartTalk();
        }

        internal void StopTalk()
        {
            nvr.StopTalk();
        }

        internal void Ptz(PTZ_ControlType cmd, bool stop, int speed)
        {
            NetSDK.H264_DVR_PTZControl(LoginId, Channel, cmd, stop, speed);
        }

        public override string ToString()
        {
            return "cam(" + nvr.Ip + " #" + (Channel + 1) + ")";
        }
    }
}
