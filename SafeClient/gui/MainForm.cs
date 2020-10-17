﻿using System;
using System.Windows.Forms;
using api.dto;
using api.dto.client;
using Properties;
using service;

namespace gui
{
    public partial class MainForm : Form
    {
        private CameraGrid[] viewModes;
        private int viewModeSelected;

        public MainForm()
        {
            DI.Instance.Init();
            InitializeComponent();
            Icon = Resources.AppIcon2;

            if (DI.Instance.Type.VideoOnly())
            {
                sensorPanel1.Visible = false;
                controlPanel1.Visible = false;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DI.Instance.ServerApi.Mode(DI.Instance.ClientId, StandMode.Close, DI.Instance.Type.GetType());
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
            ChangeMode(0);
        }

        private void toolStripButton6_Click(object sender, System.EventArgs e)
        {
            ChangeMode(1);
        }

        private void toolStripButton7_Click(object sender, System.EventArgs e)
        {
            ChangeMode(2);
        }

        private void toolStripButton8_Click(object sender, System.EventArgs e)
        {
            ChangeMode(3);
        }

        private void ChangeMode(int index)
        {
            viewModeSelected = index;
            UpdateMode(index, false);
            try
            {
                if (index < viewModes.Length)
                {
                    CameraGrid gridConf = viewModes[index];
                    grid.Grid(gridConf);
                    sensorPanel1.Set(gridConf.device);
                    controlPanel1.Set(gridConf.control);
                }
            }
            finally
            {
                UpdateMode(index, true);
            }
        }

        private void UpdateMode(int index, bool enable)
        {
            ToolStripButton mode = ModeButton();
            ToolStripButton[] array = new ToolStripButton[] { 
                toolStripButton5, 
                toolStripButton6,
                toolStripButton7, 
                toolStripButton8 
            };

            for (int i= 0; i < array.Length; i++)
            {
                var button = array[i];
                var select = array[index];

                button.Enabled = enable && i < viewModes.Length;
                button.Checked = button == select;
                button.Image = button == select
                    ? Resources.icons8_монитор_80_green
                    : button == mode ? Resources.icons8_монитор_80_blue : Resources.icons8_монитор_80;
            }
            Application.DoEvents();
        }

        private ToolStripButton ModeButton()
        {
            switch (DI.Instance.StandMode)
            {
                case StandMode.Mode1:
                    {
                        return toolStripButton6;
                    }
                case StandMode.Mode2:
                    {
                        return toolStripButton7;
                    }
                default:
                    {
                        return toolStripButton8;
                    }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            viewModes = DI.Instance.Type.GetMode();
            MainLabel.Text = "   «" + DI.Instance.Type.GetTitle() + "»   ";
            SetMode(DI.Instance.StandMode);
            toolStripButton5_Click(null, null);

            if (!DI.Instance.IsViewMode)
            {
                var count = DI.Instance.ServerApi.FindAlertAll().count;
                if (count > 0)
                {
                    MessageBox.Show("Найдено необработанных тревог: " + count + "!", "Внимание", MessageBoxButtons.OK);
                }
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.Text = MainLabel.Text;
            about.ShowDialog();
        }

        private void mode1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetMode(StandMode.Mode1);
            ChangeMode(1);
        }

        private void mode2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetMode(StandMode.Mode2);
            ChangeMode(2);
        }

        private void mode3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetMode(StandMode.Mode3);
            ChangeMode(3);
        }

        private void SetMode(StandMode mode)
        {
            if(DI.Instance.IsViewMode)
            {
                modeChangeButton.Enabled = false;
                return;
            }
            DI.Instance.StandMode = mode;
            Settings.Default.StandMode = mode.ToString();
            UpdateMode(viewModeSelected, true);
            var prefix = "";
            switch (mode)
            {
                case StandMode.Mode1:
                    {
                        mode1ToolStripMenuItem.Checked = true;
                        mode2ToolStripMenuItem.Checked = false;
                        mode3ToolStripMenuItem.Checked = false;
                        modeChangeButton.Text = prefix + mode1ToolStripMenuItem.Text;
                        break;
                    }
                case StandMode.Mode2:
                    {
                        mode1ToolStripMenuItem.Checked = false;
                        mode2ToolStripMenuItem.Checked = true;
                        mode3ToolStripMenuItem.Checked = false;
                        modeChangeButton.Text = prefix + mode2ToolStripMenuItem.Text;
                        break;
                    }
                case StandMode.Mode3:
                    {
                        mode1ToolStripMenuItem.Checked = false;
                        mode2ToolStripMenuItem.Checked = false;
                        mode3ToolStripMenuItem.Checked = true;
                        modeChangeButton.Text = prefix + mode3ToolStripMenuItem.Text;
                        break;
                    }
            }
            DI.Instance.ServerApi.Mode(DI.Instance.ClientId, mode, DI.Instance.Type.GetType());
        }

        private void modeChangeButton_ButtonClick(object sender, EventArgs e)
        {
            modeChangeButton.ShowDropDown();
        }
    }
}