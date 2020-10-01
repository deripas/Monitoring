using model.camera;
using Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace gui
{
    public partial class CameraPtzForm : Form
    {
        public static CameraPtzForm Instance = new CameraPtzForm();


        public CameraPtzForm()
        {
            InitializeComponent();
            Icon = Resources.AppIcon;
        }

        internal void Start(CameraController cam)
        {
            Text = cam.Name;
            cameraPtzPanel1.Start(cam);
            if(Visible)
                Activate();
            else
                Show();
        }

        private void CameraPtzForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            cameraPtzPanel1.Start(null);
            e.Cancel = true;
            Hide();
        }
    }
}
