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
                playerNavigationPanel1.NextFile += value;
            }
            remove
            {
                playerNavigationPanel1.NextFile -= value;
            }
        }

        public VideoPlayerPanel()
        {
            InitializeComponent();
            playerNavigationPanel1.StatusText += PlayerNavigationPanel1_StatusText;
        }

        private void PlayerNavigationPanel1_StatusText(string text)
        {
            speedLabel.Text = text;
        }

        internal void SelectItem(VideoFileModel fileModel)
        {
            playerNavigationPanel1.VideoPlayer = new VideoFilePlayer(this, fileModel);
        }

        internal void Start()
        {
            playerNavigationPanel1.Start();
        }

        internal void Stop()
        {
            playerNavigationPanel1.Stop();
        }
    }
}
