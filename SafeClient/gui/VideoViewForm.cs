using model.camera;
using model.video;
using System.Windows.Forms;

namespace gui
{
    public partial class VideoViewForm : Form
    {
        public static VideoViewForm Instance = new VideoViewForm();

        public VideoViewForm()
        {
            InitializeComponent();
            searchVideoFileHistoryPanel1.SelectItem += SearchVideoFileHistoryPanel1_SelectItem;
            searchVideoFileHistoryPanel1.PlayItem += SearchVideoFileHistoryPanel1_PlayItem;
            videoPlayerPanel1.NextFile += VideoPlayerPanel1_Next;
        }

        private void VideoPlayerPanel1_Next()
        {
            searchVideoFileHistoryPanel1.NextItem();
        }

        private void SearchVideoFileHistoryPanel1_PlayItem()
        {
            videoPlayerPanel1.Start();
        }

        private void SearchVideoFileHistoryPanel1_SelectItem(VideoFileModel video)
        {
            videoPlayerPanel1.SelectItem(video);
        }

        private void VideoViewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            videoPlayerPanel1.Stop();
            Hide();
        }

        internal void Start()
        {
            Start(null);
        }

        internal void Start(CameraController cam)
        {
            searchVideoFileHistoryPanel1.Start(cam);
            if (Visible)
                Activate();
            else
                Show();
        }
    }
}
