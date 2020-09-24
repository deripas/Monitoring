using api;
using api.dto;
using System;
using System.Configuration;
using NetSDKCS;
using SDK_HANDLE = System.Int32;

namespace model.nvr
{
    public class NvrModel
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();
        private static readonly int DetectTimeSec = Int32.Parse(ConfigurationManager.AppSettings["nvr.detect.time.sec"]);
        private static readonly int KeepLifeTimeSec = Int32.Parse(ConfigurationManager.AppSettings["nvr.keeplife.time.sec"]);
        private static readonly object LOCK = new object();

        private NvrInfo info;
        private volatile IntPtr loginId = IntPtr.Zero;
        private IntPtr talkId;
        private NET_DEVICEINFO_Ex deviceInfo;
        private int error;

        public string Ip
        {
            get
            {
                return info.ip;
            }
        }

        public IntPtr LoginId
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
                return talkId != IntPtr.Zero;
            }
        }

        public NET_MATRIX_CAMERA_INFO[] CamerasInfo = new NET_MATRIX_CAMERA_INFO[32];

        public NvrModel(NvrInfo nvrInfo)
        {
            this.info = nvrInfo;
        }

        public bool Login()
        {
            lock (LOCK)
            {
                Log.Debug("{0}: begin login", this);
                if (loginId != IntPtr.Zero)
                {
                    Log.Debug("{0}: already H264_DVR_Login", this);
                    return true;
                }

                deviceInfo = new NET_DEVICEINFO_Ex();
                loginId = NETClient.Login(info.ip, info.port, info.login, info.password, EM_LOGIN_SPAC_CAP_TYPE.TCP, IntPtr.Zero, ref deviceInfo);
                if (loginId != IntPtr.Zero)
                {
                    Log.Info("{0}: NETClient.Login - OK {1}", this, loginId);
                    NETClient.MatrixGetCameras(LoginId, out CamerasInfo, CamerasInfo.Length, 5000);
                    return true;
                }

                Log.Info("{0}: NETClient.Login - FAIL {1}", this, NETClient.GetLastError());
                return false;
            }
        }

        public bool Logout()
        {
            Log.Debug("{0}: begin logout", this);
            if (loginId == IntPtr.Zero)
            {
                Log.Warn("{0}: already H264_DVR_Logout", this);
                return true;
            }
            Log.Info("{0}: NETClient.Logout - {1}", this, NETClient.Logout(loginId));
            loginId = IntPtr.Zero;
            return true;
        }

        internal void StartTalk()
        {
            Log.Debug("{0}: start talk", this);
            talkId = NETClient.StartTalk(loginId, null, IntPtr.Zero);
            if (talkId != IntPtr.Zero)
            {
                Log.Info("{0}: NETClient.StartTalk - OK", this);
            }
            else
            {
                Log.Info("{0}: NETClient.StartTalk -  FAIL {1}", this, NETClient.GetLastError());
            }
        }

        internal void StopTalk()
        {
            if (talkId != IntPtr.Zero)
            {
                Log.Debug("{0}: stop talk", this);
                Log.Info("{0}: NETClient.StopTalk - {1}", this, NETClient.StopTalk(talkId));
                talkId = IntPtr.Zero;
            }
        }

        public override string ToString()
        {
            return "nvr(" + info.ip + ")";
        }
    }
}
