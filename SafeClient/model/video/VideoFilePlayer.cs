using api;
using System;
using System.Threading;
using NetSDKCS;
using SDK_HANDLE = System.Int32;

namespace model.video
{
    public class VideoFilePlayer
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        private const double MAXSPEED = 16;
        private const double MINSPEED = 0.0625; // 1/16
        
        private NET_TIME m_OsdTime = new NET_TIME();
        private NET_TIME m_OsdStartTime = new NET_TIME();
        private NET_TIME m_OsdEndTime = new NET_TIME();
        private double m_CurrentSpeed;
        
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
                    PlayBackControl(PlayBackType.Pause);
                }
                else
                {
                    SetPlayPos(GetPlayPos());
                    //PlayBackControl(PlayBackType.Play);
                }
            }
        }

        public string Speed
        {
            get
            {
                return speedText;
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

        private IntPtr m_PlayBackID;
        private bool sound;
        private bool pause;
        private string speedText;

        public VideoFilePlayer(IVideoPlayerView view, VideoPlayBackSource source)
        {
            this.view = view;
            this.source = source;
            m_PlayBackID = IntPtr.Zero;
        }

        public void Start()
        {
            Start(source.BeginTime, source.EndTime);
        }
        
        public void Start(DateTime startTime, DateTime endTime)
        {
            Stop();
            m_OsdTime = NET_TIME.FromDateTime(startTime);
            m_PlayBackID = source.Play(view.Canvas.Handle, startTime, endTime);
            ShowSpeed(PlayBackType.Normal);
            if (Pause)            
                PlayBackControl(PlayBackType.Pause);
        }

        public void Stop()
        {
            if (m_PlayBackID != IntPtr.Zero)
                Log.Info("{0}: NETClient.PlayBackControl STOP - {1}", this, NETClient.PlayBackControl(m_PlayBackID, PlayBackType.Stop));
            sound = false;
            m_PlayBackID = IntPtr.Zero;
        }

        private void PlayBackControl(PlayBackType cmd)
        {
            if (m_PlayBackID != IntPtr.Zero)
            {
                Log.Info("{0}: NETClient.PlayBackControl {1} - {2}", this, cmd, NETClient.PlayBackControl(m_PlayBackID, cmd));
                ShowSpeed(cmd);
            }
        }

        public void Slow()
        {
            if (m_CurrentSpeed > MINSPEED)
                PlayBackControl(PlayBackType.Slow);
        }

        public void Fast()
        {
            if (m_CurrentSpeed < MAXSPEED)
                PlayBackControl(PlayBackType.Fast);
        }

        public void OpenSound()
        {
            if (m_PlayBackID != IntPtr.Zero)
                Log.Info("{0}: NETClient.OpenSound - {1}", this, NETClient.OpenSound(m_PlayBackID));

            sound = true;
        }

        public void CloseSound()
        {
            if (m_PlayBackID != IntPtr.Zero)
                Log.Info("{0}: NETClient.CloseSound - {1}", this, NETClient.CloseSound());

            sound = false;
        }

        public void SetPlayPos(double pos)
        {
            if (m_PlayBackID == IntPtr.Zero)
                return;

            var sec = (source.EndTime - source.BeginTime).TotalSeconds * pos;
            Start(source.BeginTime.AddSeconds(sec), source.EndTime);
        }

        public double GetPlayPos()
        {
            if (m_PlayBackID == IntPtr.Zero) return 0;
            
            NETClient.GetPlayBackOsdTime(m_PlayBackID, ref m_OsdTime, ref m_OsdStartTime, ref m_OsdEndTime);
            var osd = m_OsdTime.ToDateTime();
            if (osd <= source.BeginTime || osd > source.EndTime) return 0;
            
            var pos = (osd - source.BeginTime).TotalSeconds / (source.EndTime - source.BeginTime).TotalSeconds;

            if (pos > 0.99 && (source.EndTime - osd).TotalSeconds <= 1) return 1;
            return pos;
        }
        
        private void ShowSpeed(PlayBackType mode)
        {
            switch (mode)
            {
                case PlayBackType.Slow:
                    m_CurrentSpeed /= 2;
                    break;
                case PlayBackType.Stop:
                    m_CurrentSpeed = 0;
                    break;
                case PlayBackType.Normal:
                    m_CurrentSpeed = 1;
                    break;
                case PlayBackType.Fast:
                    m_CurrentSpeed *= 2;
                    break;
                default:
                    break;
            }
            if (mode == PlayBackType.Pause || m_CurrentSpeed == 0)
            {
                speedText = "";
                return;
            }
            if (m_CurrentSpeed < 1 && m_CurrentSpeed > 0)
            {
                int i = (int)(1 / m_CurrentSpeed);
                speedText = $"1/{i}X";
            }
            else
            {
                speedText = m_CurrentSpeed + "X";
            }
        }

        public override string ToString()
        {
            return source + " player";
        }
    }
}
