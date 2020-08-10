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
                return info.ip;
            }
        }

        public SDK_HANDLE LoginId
        {
            get
            {
                return loginId;
            }
        }

        public bool Talk
        {
            get
            {
                return talkId > 0;
            }
        }

        public NvrModel(NvrInfo nvrInfo)
        {
            this.info = nvrInfo;
        }

        public bool Login()
        {
            Log.Debug("{0}: begin login", this);
            if (loginId > 0)
            {
                Log.Warn("{0}: already H264_DVR_Login", this);
                return true;
            }

            loginId = NetSDK.H264_DVR_Login(info.ip, info.port, info.login, info.password, ref deviceInfo, out error, SocketStyle.TCPSOCKET);
            if (loginId > 0)
            {
                Log.Info("{0}: H264_DVR_Login - OK {1}", this, loginId);
                Log.Info("{0}: H264_DVR_SetKeepLifeTime - {1}", this, NetSDK.H264_DVR_SetKeepLifeTime(loginId, KeepLifeTimeSec, DetectTimeSec));
                return true;
            }
            else
            {
                Log.Info("{0}: H264_DVR_Login - FAIL {1}", this, NetSDK.GetLastErrorCode());
                return false;
            }
        }

        public bool Logout()
        {
            Log.Debug("{0}: begin logout", this);
            if (loginId <=  0)
            {
                Log.Warn("{0}: already H264_DVR_Logout", this);
                return true;
            }
            Log.Info("{0}: H264_DVR_Logout - {1}", this, NetSDK.H264_DVR_Logout(loginId));
            loginId = 0;
            return true;
        }

        internal void StartTalk()
        {
            Log.Debug("{0}: start talk", this);
            talkId = NetSDK.H264_DVR_StartLocalVoiceCom(loginId);
            if (talkId > 0)
            {
                Log.Info("{0}: H264_DVR_StartLocalVoiceCom - OK", this);
            }
            else
            {
                Log.Info("{0}: H264_DVR_StartLocalVoiceCom -  FAIL {1}", this, NetSDK.GetLastErrorCode());
                talkId = 0;
            }
        }

        internal void StopTalk()
        {
            if (talkId > 0)
            {
                Log.Debug("{0}: stop talk", this);
                Log.Info("{0}: H264_DVR_StopVoiceCom - {1}", this, NetSDK.H264_DVR_StopVoiceCom(talkId));
                talkId = 0;
            }
        }

        public override string ToString()
        {
            return "nvr(" + info.ip + ")";
        }
    }
}
