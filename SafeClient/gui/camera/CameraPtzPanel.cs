using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using api;
using model.camera;

namespace gui
{
    public partial class CameraPtzPanel : UserControl
    {
        private CameraController camera;

        public CameraPtzPanel()
        {
            InitializeComponent();
        }

        internal void Start(CameraController cameraController)
        {
            camera = cameraController;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.PAN_LEFTTOP, false);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.PAN_LEFTTOP, true);
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.PAN_LEFTTOP, true);
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.TILT_UP, false);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.TILT_UP, true);
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.TILT_UP, true);
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.PAN_RIGTHTOP, false);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.PAN_RIGTHTOP, true);
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.PAN_RIGTHTOP, true);
        }

        private void button6_MouseDown(object sender, MouseEventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.PAN_RIGHT, false);
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.PAN_RIGHT, true);
        }

        private void button6_MouseUp(object sender, MouseEventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.PAN_RIGHT, true);
        }

        private void button9_MouseDown(object sender, MouseEventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.PAN_RIGTHDOWN, false);
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.PAN_RIGTHDOWN, true);
        }

        private void button9_MouseUp(object sender, MouseEventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.PAN_RIGTHDOWN, true);
        }

        private void button8_MouseDown(object sender, MouseEventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.TILT_DOWN, false);
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.TILT_DOWN, true);
        }

        private void button8_MouseUp(object sender, MouseEventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.TILT_DOWN, true);
        }

        private void button7_MouseDown(object sender, MouseEventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.PAN_LEFTDOWN, false);
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.PAN_LEFTDOWN, true);
        }

        private void button7_MouseUp(object sender, MouseEventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.PAN_LEFTDOWN, true);
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.PAN_LEFT, false);
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.PAN_LEFT, true);
        }

        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.PAN_LEFT, true);
        }

        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.ZOOM_OUT, false);
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.ZOOM_OUT, true);
        }

        private void button5_MouseUp(object sender, MouseEventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.ZOOM_OUT, true);
        }

        private void button10_MouseDown(object sender, MouseEventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.ZOOM_IN, false);
        }

        private void button10_MouseLeave(object sender, EventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.ZOOM_IN, true);
        }

        private void button10_MouseUp(object sender, MouseEventArgs e)
        {
            camera?.Ptz(PTZ_ControlType.ZOOM_IN, true);
        }
    }
}
