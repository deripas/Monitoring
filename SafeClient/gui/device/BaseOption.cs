using System.Windows.Forms;
using api.dto;
using model.device;
using service;

namespace gui
{
    public partial class BaseOption : UserControl
    {
        private DeviceInfo device;

        public DeviceInfo Device
        {
            set
            {
                device = value;
                idText.Text = value.id.ToString();
                typeText.Text = value.type.ToString();
                enableCheckBox.Checked = !value.removed;
                descText.Text = value.description;
            }
        }

        public BaseOption()
        {
            InitializeComponent();
            idText.Enabled = false;
            typeText.Enabled = false;
        }

        internal void Save(Config config, DeviceController dev)
        {
            if (device.removed != !enableCheckBox.Checked
                || !device.description.Equals(descText.Text))
            {
                config.simple = new SafeServer.dto.config.Base();
                config.simple.enable = enableCheckBox.Checked;
                config.simple.description = descText.Text;

                dev.Removed = !enableCheckBox.Checked;
                dev.Description = descText.Text;
            }
        }
    }
}
