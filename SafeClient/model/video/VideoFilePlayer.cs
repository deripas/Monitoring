using api;
using System;
using System.Threading;
using SDK_HANDLE = System.Int32;

namespace model.video
{
    public class VideoFilePlayer
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

        public int Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = (value >= -4) && (value <= 4) ? value : speed;
                if (speed >= 0)
                    PlayBackControl(PlayBackAction.SDK_PLAY_BACK_FAST, speed);
                else
                    PlayBackControl(PlayBackAction.SDK_PLAY_BACK_SLOW, -speed);
            }
        }

        public bool Sound
        {
            get
            {
                return sound;
            }
            set
            {
                sound = value;
                if (sound)
                    OpenSound();
                else
                    CloseSound();
            }
        }

        private IVideoPlayerView view;
        private VideoPlayBackSource source;

        private SDK_HANDLE playHandleId;
        private bool sound;
        private bool pause;
        private int speed;

        public VideoFilePlayer(IVideoPlayerView view, VideoPlayBackSource source)
        {
            this.view = view;
            this.source = source;
            playHandleId = -1;
        }

        public void Start()
        {
            playHandleId = source.Play(view.Canvas.Handle);
            if (playHandleId < 0) Stop();
        }

        public void Stop()
        {
            if (playHandleId >= 0)
                Log.Info("{0}: H264_DVR_StopPlayBack - {1}", this, NetSDK.H264_DVR_StopPlayBack(playHandleId));
            sound = false;
            playHandleId = -1;
        }

        private void PlayBackControl(PlayBackAction cmd, int val)
        {
            if (playHandleId >= 0)
                Log.Info("{0}: H264_DVR_PlayBackControl {1}({2}) - {3}", this, cmd, val, NetSDK.H264_DVR_PlayBackControl(playHandleId, cmd, val));
        }

        public void Slow()
        {
            Speed--;
        }

        public void Fast()
        {
            Speed++;
        }

        public void NextFrame()
        {
            float pos = GetPlayPos();
            int p = Convert.ToInt32(pos * 100);
            PlayBackControl(PlayBackAction.SDK_PLAY_BACK_SEEK_PERCENT, Math.Min(p + 1, 100));
        }

        public void PrevFrame()
        {
            float pos = GetPlayPos();
            int p = Convert.ToInt32(pos * 100);
            PlayBackControl(PlayBackAction.SDK_PLAY_BACK_SEEK_PERCENT, Math.Max(p - 1, 0));
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
            {
                var result = NetSDK.H264_DVR_SetPlayPos(playHandleId, pos);
                if(result)
                    Log.Info("{0}: H264_DVR_SetPlayPos {1} - OK", this, pos);
                else
                    Log.Info("{0}: H264_DVR_SetPlayPos {1} - FAIL {2}", this, pos, NetSDK.GetLastErrorCode());
            }
        }

        public float GetPlayPos()
        {
            if (playHandleId < 0) return 0;
            float pos = NetSDK.H264_DVR_GetPlayPos(playHandleId);
            return pos;
        }

        public override string ToString()
        {
            return source.ToString() + " player";
        }
    }
}
