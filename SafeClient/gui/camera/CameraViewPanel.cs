using model.camera;
using Properties;
using service;
using System;
using System.Windows.Forms;

namespace gui
{
    public partial class CameraViewPanel : UserControl, ICameraView
    {
        private CameraController camera;

        public double Ratio
        {
            get
            {
                return canvas.Ratio;
            }
            set
            {
                canvas.Ratio = value;
            }
        }

        public PictureBox Canvas
        {
            get
            {
                return canvas.Canvas;
            }
        }

        public CameraViewPanel()
        {
            InitializeComponent();
            canvas.Canvas.Image = Resources.no_image;
        }

        private void contextMenu_VisibleChanged(object sender, EventArgs e)
        {
            var streamNum = camera?.GetStream(this);
            var sound = camera?.Sound(this);
            var talk = camera?.Talk();
            mainToolStripMenuItem.Checked = streamNum == 0;
            subToolStripMenuItem.Checked = streamNum == 1;
            soundToolStripMenuItem.Checked = sound == true;
            talkToolStripMenuItem.Checked = talk == true;
            cameraToolStripMenuItem.SelectedItem = camera;
        }

        private void soundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (soundToolStripMenuItem.Checked)
                camera?.OpenSound(this);
            else
                camera?.CloseSound(this);
        }

        private void talkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (talkToolStripMenuItem.Checked)
                camera?.StartTalk();
            else
                camera?.StopTalk();
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

        private void mainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            camera?.SetStream(this, 0);
        }

        private void subToolStripMenuItem_Click(object sender, EventArgs e)
        {
            camera?.SetStream(this, 1);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            canvas.Ratio = 3D / 4D;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            canvas.Ratio = 9D / 16D;
        }

        private void cameraToolStripMenuItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            CameraController cam = (CameraController)cameraToolStripMenuItem.SelectedItem;
            if (cam != camera)
                StartPlay(cam);

            contextMenu.Hide();
        }

        private void pTZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CameraPtzForm.Instance.Start(camera);
        }

        private void canvas_Load(object sender, EventArgs e)
        {
            cameraToolStripMenuItem.Items.Clear();
            cameraToolStripMenuItem.Items.AddRange(DI.Instance.CameraService.CameraList.ToArray());
        }

        private void canvas_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
