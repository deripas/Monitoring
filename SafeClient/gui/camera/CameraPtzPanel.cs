using System;
using System.Windows.Forms;
using api;
using model.camera;

namespace gui
{
    public partial class CameraPtzPanel : UserControl
    {
        private CameraController camera;
        private bool mouseDown;

        public CameraPtzPanel()
        {
            InitializeComponent();
        }

        internal void Start(CameraController cameraController)
        {
            camera = cameraController;
            checkBox1.Checked = false;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            camera?.Ptz(PTZ_ControlType.PAN_LEFTTOP, false);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            if (mouseDown)
                camera?.Ptz(PTZ_ControlType.PAN_LEFTTOP, true);
            mouseDown = false;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.PAN_LEFTTOP, true);
            mouseDown = false;
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            camera?.Ptz(PTZ_ControlType.TILT_UP, false);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            if (mouseDown)
                camera?.Ptz(PTZ_ControlType.TILT_UP, true);
            mouseDown = false;
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.TILT_UP, true);
            mouseDown = false;
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            camera?.Ptz(PTZ_ControlType.PAN_RIGTHTOP, false);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            if (mouseDown)
                camera?.Ptz(PTZ_ControlType.PAN_RIGTHTOP, true);
            mouseDown = false;
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.PAN_RIGTHTOP, true);
            mouseDown = false;
        }

        private void button6_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            camera?.Ptz(PTZ_ControlType.PAN_RIGHT, false);
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            if (mouseDown)
                camera?.Ptz(PTZ_ControlType.PAN_RIGHT, true);
            mouseDown = false;
        }

        private void button6_MouseUp(object sender, MouseEventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.PAN_RIGHT, true);
            mouseDown = false;
        }

        private void button9_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            camera?.Ptz(PTZ_ControlType.PAN_RIGTHDOWN, false);
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            if (mouseDown)
                camera?.Ptz(PTZ_ControlType.PAN_RIGTHDOWN, true);
            mouseDown = false;
        }

        private void button9_MouseUp(object sender, MouseEventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.PAN_RIGTHDOWN, true);
            mouseDown = false;
        }

        private void button8_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            camera?.Ptz(PTZ_ControlType.TILT_DOWN, false);
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            if (mouseDown)
                camera?.Ptz(PTZ_ControlType.TILT_DOWN, true);
            mouseDown = false;
        }

        private void button8_MouseUp(object sender, MouseEventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.TILT_DOWN, true);
            mouseDown = false;
        }

        private void button7_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            camera?.Ptz(PTZ_ControlType.PAN_LEFTDOWN, false);
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            if (mouseDown)
                camera?.Ptz(PTZ_ControlType.PAN_LEFTDOWN, true);
            mouseDown = false;
        }

        private void button7_MouseUp(object sender, MouseEventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.PAN_LEFTDOWN, true);
            mouseDown = false;
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            camera?.Ptz(PTZ_ControlType.PAN_LEFT, false);
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            if (mouseDown)
                camera?.Ptz(PTZ_ControlType.PAN_LEFT, true);
            mouseDown = false;
        }

        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.PAN_LEFT, true);
            mouseDown = false;
        }

        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            camera?.Ptz(PTZ_ControlType.ZOOM_OUT, false);
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            if (mouseDown)
                camera?.Ptz(PTZ_ControlType.ZOOM_OUT, true);
            mouseDown = false;
        }

        private void button5_MouseUp(object sender, MouseEventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.ZOOM_OUT, true);
            mouseDown = false;
        }

        private void button10_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            camera?.Ptz(PTZ_ControlType.ZOOM_IN, false);
        }

        private void button10_MouseLeave(object sender, EventArgs e)
        {
            if (mouseDown)
                camera?.Ptz(PTZ_ControlType.ZOOM_IN, true);
            mouseDown = false;
        }

        private void button10_MouseUp(object sender, MouseEventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.ZOOM_IN, true);
            mouseDown = false;
        }

        private void buttonCenter_Click(object sender, EventArgs e)
        {
            camera?.Preset(81);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Text = "🗦💡🗧";
                camera?.Preset(103);
            }
            else
            {
                checkBox1.Text = "💡";
                camera?.Preset(101);
                camera?.Preset(102);
            }
        }

        private void buttonSetPos_Click(object sender, EventArgs e)
        {
            camera?.Preset(97);
            camera?.Preset(183);
        }
    }
}
