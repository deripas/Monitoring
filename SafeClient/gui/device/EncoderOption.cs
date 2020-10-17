using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using api.dto;
using SafeServer.dto.config;

namespace gui.device
{
    public partial class EncoderOption : UserControl
    {
        public DeviceInfo Device
        {
            set
            {
                Encoder config = value.config?.counter;
                if (config != null)
                {
                    Visible = true;
                    Enabled = true;
                    valueText.Text = config.threshold.ToString();
                }
                else
                {
                    Visible = false;
                    Enabled = false;
                }
            }
        }

        public EncoderOption()
        {
            InitializeComponent();
        }

        internal void Save(Config config)
        {
            if (Enabled)
            {
                config.counter = new Encoder
                {
                    threshold = Int32.Parse(valueText.Text)
                };
            }
        }
    }
}
