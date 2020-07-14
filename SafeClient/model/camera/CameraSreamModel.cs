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
        private long ticks;
        private bool sound;

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
            Log.Debug("{0}: stop play live video", this);
            if (playHandleId > 0)
            {
                Log.Info("{0}: H264_DVR_DelRealDataCallBack - {1}", this, NetSDK.H264_DVR_DelRealDataCallBack(playHandleId, realDataCallBack, IntPtr.Zero));
                Log.Info("{0}: H264_DVR_StopRealPlay - {1}", this, NetSDK.H264_DVR_StopRealPlay(playHandleId, 0));
            }
            playHandleId = 0;
        }

        public override string ToString()
        {
            return camera.ToString();
        }
    }
}
