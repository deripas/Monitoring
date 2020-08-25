using Properties;
using service;
using System.Drawing;
using System.Windows.Forms;
using model.device;

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
                return alarm;
            }
            set
            {
                if (!alarm && value) DI.Instance.AlarmSoundService.Play();

                alarm = value;
                led.Image = value ? Resources.led_red : Resources.led_green;
            }
        }

        public bool EnabledLed
        {
            get
            {
                return led.Image != Resources.led_gray;
            }
            set
            {
                led.Image = value
                    ? alarm ? Resources.led_red : Resources.led_green
                    : Resources.led_gray;
            }
        }

        public DeviceController Device
        {
            get => device;
            set
            {
                device = value;
                Description = value.Description;
                EnabledLed = value.Enable;
            }
        }

        private bool alarm;
        private DeviceController device;

        public BaseSensor()
        {
            InitializeComponent();
        }

        private void led_MouseClick(object sender, MouseEventArgs e)
        {
            if (device == null) return;

            DI.Instance.AlarmSoundService.Stop();
            DI.Instance.ServerApi.ResetDeviceAlert(device.Id);
        }
    }
}
