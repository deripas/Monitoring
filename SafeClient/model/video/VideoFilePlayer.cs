using api;
using System;
using System.Threading;
using SDK_HANDLE = System.Int32;

namespace model.video
{
    class VideoFilePlayer
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        public bool Pause
        {
            get
            {
                return pause;
            }
            set
            {
                pause = value;
                if (pause)
                {
                    PlayBackControl(PlayBackAction.SDK_PLAY_BACK_PAUSE, 0);
                }
                else
                {
                    PlayBackControl(PlayBackAction.SDK_PLAY_BACK_CONTINUE, 0);
                    PlayBackControl(PlayBackAction.SDK_PLAY_BACK_FAST, 0);
                    speed = 0;
                }
            }
        }
        private IVideoPlayerView view;
        private VideoFileModel model;

        private NetSDK.fDownLoadPosCallBack downloadCallBack;
        private NetSDK.fRealDataCallBack realDataCallBack;
        private SDK_HANDLE playHandleId;
        private bool sound;
        private bool pause;
        private int speed;

        public VideoFilePlayer(IVideoPlayerView view, VideoFileModel model)
        {
            this.view = view;
            this.model = model;

            downloadCallBack = new NetSDK.fDownLoadPosCallBack(DownLoadPosCallback);
            realDataCallBack = new NetSDK.fRealDataCallBack(RealDataCallBack);
            playHandleId = -1;
        }

        public int RealDataCallBack(SDK_HANDLE lRealHandle, int dwDataType, IntPtr pBuffer, UInt32 lbufsize, IntPtr dwUser)
        {
            return 1;
        }

        public void DownLoadPosCallback(SDK_HANDLE lPlayHandle, int lTotalSize, int lDownLoadSize, IntPtr dwUser)
        {
        }

        public void Start()
        {
            var data = model.Data;
            data.hWnd = view.Canvas.Handle;
            playHandleId = NetSDK.H264_DVR_PlayBackByName(model.LoginId, ref data, downloadCallBack, realDataCallBack, view.Canvas.Handle);
            if (playHandleId >= 0)
            {
                Log.Info("{0}: H264_DVR_PlayBackByName - OK", this);
            }
            else
            {
                Log.Info("{0}: H264_DVR_PlayBackByName -  FAIL {1}", this, NetSDK.GetLastErrorCode());
                Stop();
            }
        }

        public void Stop()
        {
            if (playHandleId >= 0)
                Log.Info("{0}: H264_DVR_StopPlayBack - {1}", this, NetSDK.H264_DVR_StopPlayBack(playHandleId));
            
            playHandleId = -1;
        }

        private void PlayBackControl(PlayBackAction cmd, int val)
        {
            if (playHandleId >= 0)
                Log.Info("{0}: H264_DVR_PlayBackControl {1}({2}) - {3}", this, cmd, val, NetSDK.H264_DVR_PlayBackControl(playHandleId, cmd, val));
        }

        public void Slow()
        {
            if (speed > -4) speed--;
            Speed(speed);
        }

        public void Fast()
        {
            if (speed < 4) speed++;
            Speed(speed);
        }

        private void Speed(int val)
        {
            if(val >= 0)
                PlayBackControl(PlayBackAction.SDK_PLAY_BACK_FAST, val);
            else
                PlayBackControl(PlayBackAction.SDK_PLAY_BACK_SLOW, -val);
        }

        private void Refresh()
        {
            if (Pause)
            {
                Pause = false;
                Thread.Sleep(200);
                Pause = true;
            }
        }

        public void NextFrame()
        {
            float pos = GetPlayPos();
            int p = Convert.ToInt32(pos * 100);
            PlayBackControl(PlayBackAction.SDK_PLAY_BACK_SEEK_PERCENT, p + 1);
        }

        public void PrevFrame()
        {
            float pos = GetPlayPos();
            int p = Convert.ToInt32(pos * 100);
            PlayBackControl(PlayBackAction.SDK_PLAY_BACK_SEEK_PERCENT, p - 1);
        }

        public void OpenSound()
        {
            if (playHandleId >= 0)
                Log.Info("{0}: H264_DVR_OpenSound - {1}", this, NetSDK.H264_DVR_OpenSound(playHandleId));

            sound = true;
        }

        public void CloseSound()
        {
            if (playHandleId >= 0)
                Log.Info("{0}: H264_DVR_CloseSound - {1}", this, NetSDK.H264_DVR_CloseSound(playHandleId));

            sound = false;
        }

        public void SetPlayPos(float pos)
        {
            if (playHandleId >= 0)
                Log.Info("{0}: H264_DVR_SetPlayPos {1} - {2}", this, pos, NetSDK.H264_DVR_SetPlayPos(playHandleId, pos));
        }

        public float GetPlayPos()
        {
            if (playHandleId < 0) return 0;
            float pos = NetSDK.H264_DVR_GetPlayPos(playHandleId);
            return pos;
        }

        public override string ToString()
        {
            return model.ToString() + " player";
        }
    }
}
