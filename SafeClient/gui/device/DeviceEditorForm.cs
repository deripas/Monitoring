using api.dto;
using model.device;
using Properties;
using System;
using System.Windows.Forms;

namespace gui.device
{
    public partial class DeviceEditorForm : Form
    {
        public DeviceEditorForm()
        {
            InitializeComponent();
            Icon = Resources.AppIcon2;
        }

        public DeviceInfo Device
        {
            set
            {
                Text = value.name;
                baseOption1.Device = value;
                alarmOption1.Device = value;
                measureOption1.Device = value;

                Height = baseOption1.Height +
                    (alarmOption1.Enabled ? alarmOption1.Height : 0) +
                    (measureOption1.Enabled ? measureOption1.Height : 0) +
                    150;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        public void Save(Config config, DeviceController dev)
        {
            baseOption1.Save(config, dev);
            alarmOption1.Save(config);
            measureOption1.Save(config);
        }
    }
}
