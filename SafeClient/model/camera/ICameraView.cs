using System;
using System.Windows.Forms;

namespace model.camera
{
    interface ICameraView
    {
        double Ratio { get; set; }

        PictureBox Canvas { get; }
    }
}
