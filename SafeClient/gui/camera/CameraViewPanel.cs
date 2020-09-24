using model.camera;
using Properties;
using service;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Media;

namespace gui
{
    public partial class CameraViewPanel : UserControl, ICameraView
    {
        private CameraController camera;

        public bool MainStream
        {
            set
            {
                camera?.SetStream(this, value ? 0 : 1);
            }
        }

        public int Id
        {
            get
            {
                return camera.Id;
            }
        }

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

        public bool Selected
        {
            get
            {
                return canvas.Selected;
            }
            set
            {
                canvas.Selected = value;
                canvas.BackColor = value ? System.Drawing.Color.Red : System.Drawing.Color.Black;
            }
        }

        public PictureBox Canvas
        {
            get
            {
                return canvas.Canvas;
            }
        }

        public event Action<CameraViewPanel> DoubleClick;

        public CameraViewPanel()
        {
            InitializeComponent();
            canvas.Canvas.Image = Resources.no_image;
            canvas.Canvas.MouseDoubleClick += Canvas_MouseDoubleClick;
            canvas.Canvas.MouseClick += Canvas_MouseClick;

        }

        private void Canvas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DoubleClick?.Invoke(this);
        }

        private void Canvas_MouseClick(object sender, MouseEventArgs e)
        {

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

        }

        internal void StartPlay(CameraController cameraController, int stream)
        {
            StopPlay();
            camera = cameraController;
            camera.StartPlay(this, stream);
            contextMenu.Enabled = true;
            toolTip1.SetToolTip(Canvas, camera.Name);
            canvas.Canvas.Image = null;
        }

        internal void Empty()
        {
            try
            {
                canvas.Canvas.Image = Image.FromFile("empty.png");
            }
            catch (Exception e)
            {
                canvas.Canvas.Image = Resources.lmz;
            }
        }

        internal void StopPlay()
        {
            canvas.Canvas.Image = Resources.no_image;
            Selected = false;
            camera?.StopPlay(this);
            camera = null;
            contextMenu.Enabled = false;
            toolTip1.RemoveAll();
        }

        private void mainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainStream = true;
        }

        private void subToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainStream = false;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var ratio = 3D / 4D;
            camera.Ratio = ratio;
            canvas.Ratio = ratio;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var ratio = 9D / 16D;
            camera.Ratio = ratio;
            canvas.Ratio = ratio;
        }

        private void cameraToolStripMenuItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            CameraController cam = (CameraController)cameraToolStripMenuItem.SelectedItem;
            if (cam != camera)
                StartPlay(cam, camera.GetStream(this));

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
    }
}
