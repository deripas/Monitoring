using System.Windows.Forms;

namespace model.video
{
    public interface IVideoPlayerView
    {
        double Ratio { get; set; }

        PictureBox Canvas { get; }

        void RefreshCanvas();
    }
}
