﻿using System;
using System.Windows.Forms;
using api.dto;
using Properties;
using service;

namespace gui
{
    public partial class MainForm : Form
    {
        private CameraGrid[] mode;

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
            UpdateMode(index, false);
            try
            {
                if (index < mode.Length)
                {
                    CameraGrid gridConf = mode[index];
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
            ToolStripButton[] array = new ToolStripButton[] { toolStripButton5, toolStripButton6, toolStripButton7, toolStripButton8 };
            for(int i= 0; i < array.Length; i++)
            {
                var button = array[i];
                var select = array[index];

                button.Enabled = enable && i < mode.Length;
                button.Checked = button == select;
                button.Image = button == select
                    ? Resources.led_green
                    : Resources.led_gray;
            }
            Application.DoEvents();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            mode = DI.Instance.Type.GetMode();
            toolStripButton5_Click(null, null);

            var count = DI.Instance.ServerApi.FindAlertAll().count;
            if (count > 0)
            {
                MessageBox.Show("Найдено необработанных тревог: " + count + "!", "Внимание", MessageBoxButtons.OK);
            }
        }
    }
}