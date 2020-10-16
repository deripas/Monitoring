using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using model.device;
using SafeServer.dto.config;
using api.dto;

namespace gui
{
    public partial class MeasureOption : UserControl
    {
        private DeviceInfo device;

        public DeviceInfo Device
        {
            set
            {
                this.device = value;
                Calibr config = value.config?.calibr;
                if (config != null)
                {
                    Visible = true;
                    Enabled = true;
                    minText.Text = config.min.ToString();
                    maxText.Text = config.max.ToString();
                    thresholdMaxText.Text = config.porogMax.ToString();
                    thresholdMinText.Text = config.porogMin.ToString();
                }
                else
                {
                    Visible = false;
                    Enabled = false;
                }
            }
        }

        internal void Save(Config config)
        {
            if (Enabled)
            {
                config.calibr = new Calibr
                {
                    min = Double.Parse(minText.Text),
                    max = Double.Parse(maxText.Text),
                    porogMin = Double.Parse(thresholdMinText.Text),
                    porogMax = Double.Parse(thresholdMaxText.Text)
                };
                device.config.calibr = config.calibr;
            }
        }

        public MeasureOption()
        {
            InitializeComponent();
        }
    }
}
