using model.camera;
using System;
using System.Windows.Forms;

namespace gui
{
    public partial class CameraViewPanel : UserControl, ICameraView
    {
        private CameraController camera;

        public CameraViewPanel()
        {
            InitializeComponent();
        }

        public IntPtr Canvas()
        {
            return canvas.Canvas.Handle;
        }

        private void contextMenu_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void soundToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        internal void StartPlay(CameraController cameraController)
        {
            StopPlay();
            camera = cameraController;
            camera.StartPlay(this);
        }

        internal void StopPlay()
        {
            camera?.StopPlay(this);
            camera = null;
        }
    }
}
