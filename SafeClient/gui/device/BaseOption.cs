using System.Windows.Forms;
using api.dto;
using model.device;
using service;

namespace gui
{
    public partial class BaseOption : UserControl
    {
        public DeviceInfo Device
        {
            set
            {
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
            config.simple = new SafeServer.dto.config.Base
            {
                enable = enableCheckBox.Checked,
                description = descText.Text
            };

            dev.Removed = !enableCheckBox.Checked;
            dev.Description = descText.Text;
            dev.Refresh();
        }
    }
}
