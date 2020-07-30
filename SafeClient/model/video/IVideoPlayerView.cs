using System.Windows.Forms;

namespace model.video
{
    interface IVideoPlayerView
    {
        double Ratio { get; set; }

        PictureBox Canvas { get; }
    }
}
