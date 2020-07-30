using api;
using model.video;
using System.Windows.Forms;

namespace gui
{
    public partial class VideoPlayerPanel : UserControl, IVideoPlayerView
    {
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

        private VideoFileStreamModel stream;

        public VideoPlayerPanel()
        {
            InitializeComponent();
            playerControlPanel1.Play += PlayerControlPanel1_Play;
            playerControlPanel1.Pause += PlayerControlPanel1_Pause;
            playerControlPanel1.Speed += PlayerControlPanel1_Speed;
        }

        private void PlayerControlPanel1_Speed(int speed)
        {
            if (speed > 0)
                stream?.Control(PlayBackAction.SDK_PLAY_BACK_FAST, speed);
            if (speed < 0)
                stream?.Control(PlayBackAction.SDK_PLAY_BACK_SLOW, -speed);
        }

        private void PlayerControlPanel1_Pause(bool run)
        {
            if (run)
                stream?.Control(PlayBackAction.SDK_PLAY_BACK_PAUSE);
            else
                stream?.Control(PlayBackAction.SDK_PLAY_BACK_CONTINUE);
        }

        private void PlayerControlPanel1_Play(bool run)
        {
            if (run)
                stream?.Start();
            else
                stream?.Stop();
        }

        internal void Start(VideoFileModel fileModel)
        {
            stream?.Stop();
            stream = new VideoFileStreamModel(fileModel, canvasPanel1.Canvas);
            playerControlPanel1.Ready();
        }

        internal void Stop()
        {
            stream?.Stop();
            playerControlPanel1.Ready();
        }
    }
}
