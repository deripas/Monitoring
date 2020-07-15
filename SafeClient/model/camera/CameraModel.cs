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
        private int channel;

        public int Channel
        {
            get
            {
                return channel;
            }
        }

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
            this.channel = channel;
        }

        internal void StartTalk()
        {
            nvr.StartTalk();
        }

        internal void StopTalk()
        {
            nvr.StopTalk();
        }

        public override string ToString()
        {
            return "cam(" + nvr.Ip + " #" + (channel + 1) + ")";
        }
    }
}
