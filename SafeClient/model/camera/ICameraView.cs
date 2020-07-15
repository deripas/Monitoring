using System;

namespace model.camera
{
    interface ICameraView
    {
        IntPtr Canvas();

        void Disconnect();

        void Connect();
    }
}
