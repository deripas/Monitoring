using System;
using System.Windows.Forms;
using model.device;
using api.dto;
using Properties;
using service;
using System.CodeDom;

namespace gui
{
    public partial class ClassicHurbleControl : UserControl, SensorView
    {
        private DeviceController device;
        private long check;
        private long alarm;
        private bool enable;
        private ControlType last = ControlType.NULL;

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

        public DeviceController Device
        {
            get => device;
            set
            {
                device = value;
                if (value != null)
                {
                    Description = value.Description;
                }
            }
        }

        public ClassicHurbleControl()
        {
            InitializeComponent();
        }

        public Control GetControl()
        {
            return this;
        }

        public void Set(DeviceController dev)
        {
            Device = dev;
            modeAuto.Enabled = dev.Config.counter != null;
        }

        public void Update(SensorStatus status)
        {
            Enabled = status.enable;
            EnabledLed = status.enable;
            SetAlarm(status.alarm);
            SetImage((ControlType)status.value);
            SetControll((ControlType)status.value);
            last = (ControlType)status.value;
        }

        internal void SetImage(ControlType type)
        {
            if (Alarm)
            {
                pictureIcon.Image = Resources.classic_alarm;
            }
            else
            {
                pictureIcon.Image = type.HasFlag(ControlType.POWER)
                        ? Resources.classic_close
                        : Resources.classic_open;
            }
        }

        internal void SetControll(ControlType type)
        {
            if (type.HasFlag(ControlType.ON)) modeoOn.Checked = true;
            if (type.HasFlag(ControlType.OFF)) modeOff.Checked = true;
            if (type.HasFlag(ControlType.AUTO)) modeAuto.Checked = true;
        }

        internal void SetAlarm(long alarm)
        {
            if (!Enabled) return;

            if (alarm > this.alarm)
            {
                DI.Instance.AlarmSoundService.Play();
            }
            this.alarm = alarm;
            UpdateLed();
        }

        private void UpdateLed()
        {
            if (enable)
            {
                led.Image = Alarm
                    ? alarm == check ? Resources.led_orange : Resources.led_red
                    : Resources.led_green;
            }
            else
            {
                led.Image = Resources.led_gray;
            }
        }

        private void led_MouseClick(object sender, MouseEventArgs e)
        {
            if (device == null) return;

            if (Alarm)
            {
                DI.Instance.AlarmSoundService.Stop();
                DI.Instance.ServerApi.ResetDeviceAlert(device.Id);
                check = alarm;
                UpdateLed();
            }
        }

        private void modeOff_Click(object sender, EventArgs e)
        {
            if (modeOff.Checked && !last.HasFlag(ControlType.OFF))
            {
                DI.Instance.DeviceService.HurbleOff(device.Id);
                SetImage(last ^ ControlType.POWER);
            }
        }

        private void modeoOn_Click(object sender, EventArgs e)
        {
            if (modeoOn.Checked && !last.HasFlag(ControlType.ON))
            {
                DI.Instance.DeviceService.HurbleOn(device.Id);
                SetImage(last | ControlType.POWER);
            }
        }

        private void modeAuto_Click(object sender, EventArgs e)
        {
            if (modeAuto.Checked && !last.HasFlag(ControlType.AUTO))
            {
                DI.Instance.DeviceService.HurbleAuto(device.Id);
                if(last.HasFlag(ControlType.ENCODER))
                {
                    SetImage(last | ControlType.POWER);
                }
                else
                {
                    SetImage(last ^ ControlType.POWER);
                }
            }
        }
    }

    [Flags]
    public enum ControlType
    {
        NULL = 0,
        POWER = 1,
        REMOTE = 2,
        ENCODER = 4,
        ON = 8,
        OFF = 16,
        AUTO = 32,
    }
}
