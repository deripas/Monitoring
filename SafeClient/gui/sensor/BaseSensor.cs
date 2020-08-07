using Properties;
using System.Drawing;
using System.Windows.Forms;

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
                alarm = value;
                led.Image = value ? Resources.led_red : Resources.led_green;
            }
        }

        private bool alarm;

        public BaseSensor()
        {
            InitializeComponent();
        }
    }
}
