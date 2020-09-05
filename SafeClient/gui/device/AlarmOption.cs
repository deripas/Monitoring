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
        private DeviceController device;

        public DeviceController Device
        {
            set
            {
                this.device = value;
                Alarm config = value.Config?.alarm;
                if (config != null)
                {
                    Visible = true;
                    Enabled = true;
                    timeoutText.Text = config.timeout.ToString();
                    countText.Text = config.count.ToString();
                    periodText.Text = config.period.ToString();
                    delayText.Text = config.delay.ToString();
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
                    delay = Int64.Parse(delayText.Text),
                    period = Int64.Parse(periodText.Text),
                    timeout = Int64.Parse(timeoutText.Text)
                };
                device.Config.alarm = config.alarm;
            }
        }

        public AlarmOption()
        {
            InitializeComponent();
        }
    }
}
