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

        private VideoFilePlayer stream;
        private DateTime lastScrollTime;
        private float lastScrollVal;

        public VideoPlayerPanel()
        {
            InitializeComponent();
            lastScrollTime = DateTime.MinValue;
            lastScrollVal = -1;

            trackBar1.SetRange(0, 1000);
            playerControlPanel1.Play += PlayerControlPanel1_Play;
            playerControlPanel1.Pause += PlayerControlPanel1_Pause;
            playerControlPanel1.Slow += PlayerControlPanel1_Slow;
            playerControlPanel1.Fast += PlayerControlPanel1_Fast;

        }

        private void PlayerControlPanel1_Slow()
        {
            if (stream == null) return;

            if (stream.Pause)
                stream.PrevFrame();
            else
                stream.Slow();
        }

        private void PlayerControlPanel1_Fast()
        {
            if (stream == null) return;

            if (stream.Pause)
                stream.NextFrame();
            else
                stream.Fast();
        }

        private void PlayerControlPanel1_Pause(bool pause)
        {
            if (stream == null) return;

            stream.Pause = pause;
        }

        private void PlayerControlPanel1_Play(bool run)
        {
            if (run)
            {
                stream?.Start();
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
            stream?.Stop();
            stream = new VideoFilePlayer(this, fileModel);
            playerControlPanel1.Reset();
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
            if ((DateTime.Now - lastScrollTime).TotalSeconds < 2) return;

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
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            float v = trackBar1.Value;
            float m = trackBar1.Maximum;
            lastScrollVal = v / m;
            lastScrollTime = DateTime.Now;
        }
    }
}
