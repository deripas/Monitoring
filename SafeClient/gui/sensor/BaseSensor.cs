using Properties;
using service;
using System.Drawing;
using System.Windows.Forms;
using model.device;
using System;

namespace gui
{
    public partial class BaseSensor : UserControl
    {
        public string Title
        {
            get
            {
                return name.Text;
            }
            set
            {
                name.Text = value;
            }
        }

        public string Description
        {
            get
            {
                return description.Text;
            }
            set
            {
                description.Text = value;
            }
        }

        public string Max
        {
            get
            {
                return maximum.Text;
            }
            set
            {
                maximum.Text = value;
            }
        }

        public string Value
        {
            get
            {
                return current.Text;
            }
            set
            {
                current.Text = value;
            }
        }

        public bool Alarm
        {
            get
            {
                return alarm > 0;
            }
            set
            {
                alarm = value ? DateTime.Now.Ticks : 0;
            }
        }

        public bool EnabledLed
        {
            get
            {
                return enable;
            }
            set
            {
                enable = value;
                UpdateLed();
            }
        }

        public DeviceController Device
        {
            get => device;
            set
            {
                device = value;
                if (value != null)
                {
                    Description = value.Description;
                    EnabledLed = value.Enable;
                }
            }
        }

        private long alarm;
        private bool enable;
        private DeviceController device;

        public BaseSensor()
        {
            InitializeComponent();
        }

        private void led_MouseClick(object sender, MouseEventArgs e)
        {
            if (device == null) return;

            if (Alarm)
            {
                device.Camera.Selected = false;
                DI.Instance.AlarmSoundService.Stop();
                DI.Instance.ServerApi.ResetDeviceAlert(device.Id);
            }
        }

        private void UpdateLed()
        {
            if (enable)
            {
                led.Image = Alarm ? Resources.led_red : Resources.led_green;
            }
            else
            {
                led.Image = Resources.led_gray;
            }
        }

        internal void SetAlarm(long alarm)
        {
            if(alarm > this.alarm)
            {
                DI.Instance.AlarmSoundService.Play();
                device.Camera.Selected = true;
                this.alarm = alarm;
            }
            UpdateLed();
        }
    }
}
