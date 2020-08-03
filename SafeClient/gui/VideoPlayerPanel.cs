using api;
using model.video;
using System;
using System.Windows.Forms;

namespace gui
{
    public partial class VideoPlayerPanel : UserControl, IVideoPlayerView
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        public double Ratio
        {
            get
            {
                return canvasPanel1.Ratio;
            }
            set
            {
                canvasPanel1.Ratio = value;
            }
        }

        public PictureBox Canvas
        {
            get
            {
                return canvasPanel1.Canvas;
            }
        }

        public event Action NextFile
        {
            add
            {
                playerControlPanel1.NextFile += value;
            }
            remove
            {
                playerControlPanel1.NextFile -= value;
            }
        }

        private VideoFilePlayer stream;
        private DateTime lastScrollTime;
        private DateTime lastControlTime;
        private float lastScrollVal;

        public VideoPlayerPanel()
        {
            InitializeComponent();
            lastScrollTime = DateTime.MinValue;
            lastControlTime = DateTime.MinValue;
            lastScrollVal = -1;

            trackBar1.SetRange(0, 1000);
            playerControlPanel1.Play += PlayerControlPanel1_Play;
            playerControlPanel1.Pause += PlayerControlPanel1_Pause;
            playerControlPanel1.Slow += PlayerControlPanel1_Slow;
            playerControlPanel1.Fast += PlayerControlPanel1_Fast;
            playerControlPanel1.NextFrame += PlayerControlPanel1_NextFrame;
            playerControlPanel1.PrevFrame += PlayerControlPanel1_PrevFrame;
            playerControlPanel1.SoundEvent += PlayerControlPanel1_Sound;
        }

        private void UpdateSpeedText()
        {
            if (stream == null) speedLabel.Text = "";

            speedLabel.Text = "Скорость: " + stream.Speed;
        }

        private void PlayerControlPanel1_PrevFrame()
        {
            if (stream == null) return;

            stream.PrevFrame();
        }

        private void PlayerControlPanel1_NextFrame()
        {
            if (stream == null) return;

            stream.NextFrame();
        }

        private void PlayerControlPanel1_Sound(bool sound)
        {
            if (stream == null) return;
            stream.Sound = sound;
        }

        private void PlayerControlPanel1_Slow()
        {
            if (stream == null) return;

            stream.Slow();
            UpdateSpeedText();
        }

        private void PlayerControlPanel1_Fast()
        {
            if (stream == null) return;

            stream.Fast();
            UpdateSpeedText();
        }

        private void PlayerControlPanel1_Pause(bool pause)
        {
            if (stream == null) return;

            stream.Pause = pause;
        }

        private void PlayerControlPanel1_Play(bool run)
        {
            if (stream == null) return;
            if (run)
            {
                Log.Info("{0}: start play file", this);
                lastControlTime = DateTime.Now;
                stream.Start();
                timerPlayBack.Start();
            }
            else
            {
                stream?.Stop();
                timerPlayBack.Stop();
            }
        }

        internal void Start(VideoFileModel fileModel)
        {
            SelectItem(fileModel);
            Start();
        }

        internal void Start()
        {
            playerControlPanel1.DoPlayClick();
        }

        internal void SelectItem(VideoFileModel fileModel)
        {
            if (stream != null)
                stream.Stop();
            
            stream = new VideoFilePlayer(this, fileModel);
            playerControlPanel1.Reset();
            UpdateSpeedText();
        }

        internal void Stop()
        {
            stream?.Stop();
            timerPlayBack.Stop();
            playerControlPanel1.Reset();
        }

        private void timerPlayBack_Tick(object sender, EventArgs e)
        {
            if (stream == null) return;
            if ((DateTime.Now - lastScrollTime).TotalSeconds < 1) return;

            if (lastScrollVal > 0)
            {
                stream.SetPlayPos(lastScrollVal);
                lastScrollVal = -1;
                lastScrollTime = DateTime.Now;
            }
            else
            {
                var max = trackBar1.Maximum;
                int pos = Convert.ToInt32(stream.GetPlayPos() * max);
                if (pos < max) trackBar1.Value = pos;

                if(pos == 0 && (DateTime.Now - lastControlTime).TotalSeconds > 3)
                {
                    Log.Info("{0}: try play next file...", this);
                    playerControlPanel1.DoNextFile();
                }
            }
        }

        private void BeginScroll(float val)
        {
            lastScrollVal = val;
            lastScrollTime = DateTime.Now;
            lastControlTime = DateTime.Now;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            float v = trackBar1.Value;
            float m = trackBar1.Maximum;
            BeginScroll(v / m);
        }

        private void trackBar1_MouseDown(object sender, MouseEventArgs e)
        {
            var dX = (double)e.X / (double)trackBar1.Width;
            trackBar1.Value = Convert.ToInt32(dX * (trackBar1.Maximum - trackBar1.Minimum));
            BeginScroll((float)dX);
        }

        public override string ToString()
        {
            return "player panel";
        }
    }
}
