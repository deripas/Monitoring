using api;
using model.nvr;
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

        public CameraModel(NvrModel nvr, int channel)
        {
            this.nvr = nvr;
            this.channel = channel;
        }


        public override string ToString()
        {
            return "cam(" + nvr.Ip + " #" + (channel + 1) + ")";
        }

    }
}
