using api;
using System;
using System.Threading;
using System.Windows.Forms;
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
        private long frames;

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

        public bool StartedPlay
        {
            get
            {
                return playHandleId > 0;
            }
        }

        public DateTime LastUpdateTime
        {
            get
            {
                var t = Interlocked.Read(ref ticks);
                return new DateTime(t);
            }
        }

        public bool Play
        {
            get
            {
                var c = Interlocked.Read(ref frames);
                return c > 0;
            }
        }


        public CameraSreamModel(CameraModel camera, PictureBox canvas)
        {
            this.camera = camera;
            ticks = DateTime.MinValue.Ticks;
            frames = 0;
            info = new H264_DVR_CLIENTINFO
            {
                nChannel = camera.Channel,
                nStream = 1,
                nMode = 0,
                hWnd = canvas.Handle
            };
        }

        private int FRealDataCallBack(SDK_HANDLE lRealHandle, int dwDataType, IntPtr pBuffer, UInt32 lbufsize, IntPtr dwUser)
        {
            Interlocked.Exchange(ref ticks, DateTime.Now.Ticks);
            Interlocked.Increment(ref frames);
            return 1;
        }

        public void StartPlay()
        {
            Log.Debug("{0}: start play live video", this);
            if (playHandleId > 0)
                return;

            frames = 0;
            ticks = DateTime.Now.Ticks;
            playHandleId = NetSDK.H264_DVR_RealPlay(camera.LoginId, ref info);
            if (playHandleId > 0)
            {
                realDataCallBack = new NetSDK.fRealDataCallBack(FRealDataCallBack);
                GC.KeepAlive(realDataCallBack);

                Log.Info("{0}: H264_DVR_RealPlay - OK", this);
                Log.Info("{0}: H264_DVR_SetRealDataCallBack - {1}", this, NetSDK.H264_DVR_SetRealDataCallBack(playHandleId, realDataCallBack, IntPtr.Zero));
            }
            else
            {
                Log.Info("{0}: H264_DVR_RealPlay -  FAIL {1}", this, NetSDK.GetLastErrorCode());
                playHandleId = 0;
                realDataCallBack = null;
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
            realDataCallBack = null;
            frames = 0;
            ticks = DateTime.MinValue.Ticks;
        }

        public void ResetTime()
        {
            ticks = DateTime.Now.Ticks;
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
