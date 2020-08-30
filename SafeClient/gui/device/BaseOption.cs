using System.Windows.Forms;
using model.device;

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
                enableCheckBox.Checked = value.Enable;
                descText.Text = value.Description;
            }
        }

        public BaseOption()
        {
            InitializeComponent();
            idText.Enabled = false;
            typeText.Enabled = false;
        }

        internal void Save()
        {
            device.Enable = enableCheckBox.Checked;
            device.Description = descText.Text;
        }
    }
}
