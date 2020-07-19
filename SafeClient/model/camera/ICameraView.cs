using System;

namespace model.camera
{
    interface ICameraView
    {
        double Ratio { get; set; }

        IntPtr Canvas { get; }
    }
}
