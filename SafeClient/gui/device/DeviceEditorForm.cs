using api.dto;
using model.device;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace gui.device
{
    public partial class DeviceEditorForm : Form
    {
        public DeviceEditorForm()
        {
            InitializeComponent();
        }

        public DeviceController Device
        {
            set
            {
                Text = value.Name;
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

        public void Save(Config config)
        {
            baseOption1.Save(config);
            alarmOption1.Save(config);
            measureOption1.Save(config);
        }
    }
}
