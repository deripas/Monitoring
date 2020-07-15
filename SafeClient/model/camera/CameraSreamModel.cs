using api;
using System;
using System.Threading;
using SDK_HANDLE = System.Int32;

namespace model.camera
{
    public class CameraSreamModel
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        private CameraModel camera;
        private NetSDK.fRealDataCallBack realDataCallBack;
        private H264_DVR_CLIENTINFO info;
        private SDK_HANDLE playHandleId;
        private bool sound;
        private long ticks;

        public bool Sound
        {
            get
            {
                return sound;
            }
        }

        public int Stream
        {
            get
            {
                return info.nStream;
            }
            set
            {
                info.nStream = value;
            }
        }

        public bool Play
        {
            get
            {
                return playHandleId > 0;
            }
        }

        public DateTime LastTime
        {
            get
            {
                var t = Interlocked.Read(ref ticks);
                return new DateTime(t);
            }
        }

        public CameraSreamModel(CameraModel camera, IntPtr canvas)
        {
            this.camera = camera;
            info = new H264_DVR_CLIENTINFO
            {
                nChannel = camera.Channel,
                nStream = 1,
                nMode = 0,
                hWnd = canvas
            };
            realDataCallBack = new NetSDK.fRealDataCallBack(FRealDataCallBack);
            GC.KeepAlive(realDataCallBack);
        }

        private int FRealDataCallBack(SDK_HANDLE lRealHandle, int dwDataType, IntPtr pBuffer, int lbufsize, IntPtr dwUser)
        {
            Interlocked.Exchange(ref ticks, DateTime.Now.Ticks);
            return 1;
        }

        public bool StartPlay()
        {
            Log.Debug("{0}: start play live video", this);
            if (playHandleId > 0)
                return true;

            playHandleId = NetSDK.H264_DVR_RealPlay(camera.LoginId, ref info);
            if (playHandleId > 0)
            {
                ticks = DateTime.Now.Ticks;
                Log.Info("{0}: H264_DVR_RealPlay - OK", this);
                Log.Info("{0}: H264_DVR_SetRealDataCallBack - {1}", this, NetSDK.H264_DVR_SetRealDataCallBack(playHandleId, realDataCallBack, IntPtr.Zero));
                return true;
            }
            else
            {
                Log.Info("{0}: H264_DVR_RealPlay -  FAIL {1}", this, NetSDK.GetLastErrorCode());
                playHandleId = 0;
                return false;
            }
        }

        public void StopPlay()
        {
            camera.StopTalk();
            if (playHandleId > 0)
            {
                Log.Debug("{0}: stop play live video", this);
                Log.Info("{0}: H264_DVR_DelRealDataCallBack - {1}", this, NetSDK.H264_DVR_DelRealDataCallBack(playHandleId, realDataCallBack, IntPtr.Zero));
                Log.Info("{0}: H264_DVR_StopRealPlay - {1}", this, NetSDK.H264_DVR_StopRealPlay(playHandleId, 0));
            }
            playHandleId = 0;
        }

        public void OpenSound()
        {
            Log.Debug("{0}: open sound", this);
            Log.Info("{0}: H264_DVR_OpenSound - {1}", this, NetSDK.H264_DVR_OpenSound(playHandleId));
            sound = true;
        }

        public void CloseSound()
        {
            if (sound)
            {
                Log.Debug("{0}: close sound", this);
                Log.Info("{0}: H264_DVR_CloseSound - {1}", this, NetSDK.H264_DVR_CloseSound(playHandleId));
                sound = false;
            }
        }

        public override string ToString()
        {
            return camera.ToString();
        }
    }
}
