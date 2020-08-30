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
            baseOption1.Save();
            alarmOption1.Save();
            measureOption1.Save();
            Close();
        }
    }
}
