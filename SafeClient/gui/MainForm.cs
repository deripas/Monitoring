﻿using System;
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
            UpdateMode(toolStripButton5, false);
            try
            {
                var gridConf = CameraGrid.grid6x6();
                grid.Grid(gridConf);
                sensorPanel1.Set(gridConf.device);
            }
            finally
            {
                UpdateMode(toolStripButton5, true);
            }
        }

        private void toolStripButton6_Click(object sender, System.EventArgs e)
        {
            UpdateMode(toolStripButton6, false);
            try
            {
                var gridConf = CameraGrid.grid3x3_1();
                grid.Grid(gridConf);
                sensorPanel1.Set(gridConf.device);
                controlPanel1.Set(gridConf.control);
            }
            finally
            {
                UpdateMode(toolStripButton6, true);
            }
        }

        private void toolStripButton7_Click(object sender, System.EventArgs e)
        {
            UpdateMode(toolStripButton7, false);
            try
            {
                var gridConf = CameraGrid.grid3x3_2();
                grid.Grid(gridConf);
                sensorPanel1.Set(gridConf.device);
                controlPanel1.Set(gridConf.control);
            }
            finally
            {
                UpdateMode(toolStripButton7, true);
            }
        }

        private void toolStripButton8_Click(object sender, System.EventArgs e)
        {
            UpdateMode(toolStripButton8, false);
            try
            {
                var gridConf = CameraGrid.grid3x3_3();
                grid.Grid(gridConf);
                sensorPanel1.Set(gridConf.device);
                controlPanel1.Set(gridConf.control);
            }
            finally
            {
                UpdateMode(toolStripButton8, true);
            }
        }

        private void UpdateMode(ToolStripButton select, bool enable)
        {
            ToolStripButton[] array = new ToolStripButton[] { toolStripButton5, toolStripButton6, toolStripButton7, toolStripButton8 };
            foreach(ToolStripButton button in array)
            {
                button.Enabled = enable;
                button.Checked = button == select;
                button.Image = button == select
                    ? Resources.led_green
                    : Resources.led_gray;
            }
            Application.DoEvents();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var count = DI.Instance.ServerApi.FindAlertAll().count;
            if (count > 0)
            {
                MessageBox.Show("Найдено " + count + " необработанных тревог!", "Внимание", MessageBoxButtons.OK);
            }
        }
    }
}