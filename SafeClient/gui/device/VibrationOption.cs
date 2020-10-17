using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using api.dto;
using api.dto.config;

namespace gui.device
{
    public partial class VibrationOption : UserControl
    {
        public DeviceInfo Device
        {
            set
            {
                Vibr config = value.config?.vibr;
                if (config != null)
                {
                    Visible = true;
                    Enabled = true;
                    maxText.Text = config.porog.ToString();

                    xSnText.Text = value.config?.sensorX?.cfg?.sn;
                    xSens.Text = "" + value.config?.sensorX?.cfg?.sensitivity;

                    ySnText.Text = value.config?.sensorY?.cfg?.sn;
                    ySens.Text = "" + value.config?.sensorY?.cfg?.sensitivity;
                }
                else
                {
                    Visible = false;
                    Enabled = false;
                }
            }
        }

        public VibrationOption()
        {
            InitializeComponent();
        }

        internal void Save(Config config)
        {
            if (Enabled)
            {
                config.vibr.porog = Double.Parse(maxText.Text);
                config.vibr.scale = config.vibr.scale; // as is

                config.sensorX.cfg = new Cfg
                {
                    sn = xSnText.Text,
                    sensitivity = Double.Parse(xSens.Text)
                };

                config.sensorY.cfg = new Cfg
                {
                    sn = ySnText.Text,
                    sensitivity = Double.Parse(ySens.Text)
                };
            }
        }
    }
}
