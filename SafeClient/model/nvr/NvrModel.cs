using api;
using api.dto;
using System;
using System.Configuration;
using SDK_HANDLE = System.Int32;

namespace model.nvr
{
    public class NvrModel
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();
        private static readonly int DetectTimeSec = Int32.Parse(ConfigurationManager.AppSettings["nvr.detect.time.sec"]);
        private static readonly int KeepLifeTimeSec = Int32.Parse(ConfigurationManager.AppSettings["nvr.keeplife.time.sec"]);

        private NvrInfo info;
        private SDK_HANDLE loginId;
        private SDK_HANDLE talkId;
        private H264_DVR_DEVICEINFO deviceInfo;
        private int error;

        public string Ip
        {
            get
            {
                return info.Ip;
            }
        }

        public SDK_HANDLE LoginId
        {
            get
            {
                return loginId;
            }
        }

        public NvrModel(NvrInfo nvrInfo)
        {
            this.info = nvrInfo;
        }

        public bool Login()
        {
            Log.Debug("{0}: begin login", info);
            if (loginId > 0)
            {
                Log.Warn("{0}: already H264_DVR_Login", info);
                return true;
            }

            loginId = NetSDK.H264_DVR_Login(info.Ip, info.Port, info.Login, info.Password, ref deviceInfo, out error, SocketStyle.TCPSOCKET);
            if (loginId > 0)
            {
                Log.Info("{0}: H264_DVR_Login - OK {1}", info, loginId);
                Log.Info("{0}: H264_DVR_SetKeepLifeTime - {1}", info, NetSDK.H264_DVR_SetKeepLifeTime(loginId, KeepLifeTimeSec, DetectTimeSec));
                return true;
            }
            else
            {
                Log.Info("{0}: H264_DVR_Login - FAIL {1}", info, NetSDK.GetLastErrorCode());
                return false;
            }
        }

        public bool Logout()
        {
            Log.Debug("{0}: begin logout", info);
            if (loginId <=  0)
            {
                Log.Warn("{0}: already H264_DVR_Logout", info);
                return true;
            }
            Log.Info("{0}: H264_DVR_Logout - {1}", info, NetSDK.H264_DVR_Logout(loginId));
            loginId = 0;
            return true;
        }

        public override string ToString()
        {
            return "nvr(" + info.Ip + ")";
        }
    }
}
