using System.Windows.Forms;
using api.dto;
using model.device;
using service;

namespace gui
{
    public partial class BaseOption : UserControl
    {
        private DeviceController device;

        public DeviceController Device
        {
            set
            {
                device = value;
                idText.Text = value.Id.ToString();
                typeText.Text = value.Type.ToString();
                enableCheckBox.Checked = !value.Removed;
                descText.Text = value.Description;
            }
        }

        public BaseOption()
        {
            InitializeComponent();
            idText.Enabled = false;
            typeText.Enabled = false;
        }

        internal void Save(Config config)
        {
            if (device.Removed != !enableCheckBox.Checked
                || !device.Description.Equals(descText.Text))
            {
                config.simple = new SafeServer.dto.config.Base();
                config.simple.enable = enableCheckBox.Checked;
                config.simple.description = descText.Text;

                device.Removed = !enableCheckBox.Checked;
                device.Description = descText.Text;
            }
        }
    }
}
