using System;
using System.Windows.Forms;
using api.dto;
using Properties;
using service;

namespace gui
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            DI.Instance.Init();
            InitializeComponent();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DI.Instance.Dispose();
            CameraPtzForm.Instance.Dispose();
            VideoViewForm.Instance.Dispose();
            AlertViewForm.Instance.Dispose();
            VideoExportForm.Instance.Dispose();
            DeviceViewForm.Instance.Dispose();
            Application.Exit();
        }

        private void toolStripButton1_Click(object sender, System.EventArgs e)
        {
            VideoViewForm.Instance.Start();
        }

        private void toolStripButton2_Click(object sender, System.EventArgs e)
        {
            AlertViewForm.Instance.Start();
        }

        private void closeButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void toolStripButton3_Click(object sender, System.EventArgs e)
        {
            DeviceViewForm.Instance.Start();
        }

        private void toolStripButton5_Click(object sender, System.EventArgs e)
        {
            grid.Grid(CameraGrid.grid6x6());
            UpdateMode(toolStripButton5);
        }

        private void toolStripButton6_Click(object sender, System.EventArgs e)
        {
            grid.Grid(CameraGrid.grid3x3_1());
            UpdateMode(toolStripButton6);
        }

        private void toolStripButton7_Click(object sender, System.EventArgs e)
        {
            grid.Grid(CameraGrid.grid3x3_2());
            UpdateMode(toolStripButton7);
        }

        private void toolStripButton8_Click(object sender, System.EventArgs e)
        {
            grid.Grid(CameraGrid.grid3x3_3());
            UpdateMode(toolStripButton8);
        }

        private void UpdateMode(ToolStripButton select)
        {
            ToolStripButton[] array = new ToolStripButton[] { toolStripButton5, toolStripButton6, toolStripButton7, toolStripButton8 };
            foreach(ToolStripButton button in array)
            {
                button.Checked = button == select;
                button.Image = button == select
                    ? Resources.led_green
                    : Resources.led_gray;
            }
        }
    }
}