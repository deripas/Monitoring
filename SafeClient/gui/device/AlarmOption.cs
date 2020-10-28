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
    public partial class AlarmOption : UserControl
    {
        public DeviceInfo Device
        {
            set
            {
                Alarm config = value.config?.alarm;
                if (config != null)
                {
                    Visible = true;
                    Enabled = true;
                    countText.Text = config.count.ToString();
                    timeoutText.Text = (config.timeout / 1000).ToString();
                    periodText.Text = (config.period / 1000).ToString();
                    delayText.Text = (config.delay / 1000).ToString();

                    var enable = value.config.siren != null;
                    countText.Enabled = enable;
                    periodText.Enabled = enable;
                    delayText.Enabled = enable;
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
            if(Enabled)
            {
                config.alarm = new Alarm
                {
                    count = Int64.Parse(countText.Text),
                    delay = Int64.Parse(delayText.Text) * 1000,
                    period = Int64.Parse(periodText.Text) * 1000,
                    timeout = Int64.Parse(timeoutText.Text) * 1000
                };
            }
        }

        public AlarmOption()
        {
            InitializeComponent();
        }
    }
}
