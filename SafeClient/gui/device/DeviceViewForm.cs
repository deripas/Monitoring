using api.dto;
using gui.device;
using model.device;
using Properties;
using service;
using System;
using System.Windows.Forms;
using System.Windows.Media;

namespace gui
{
    public partial class DeviceViewForm : Form
    {
        public static DeviceViewForm Instance = new DeviceViewForm();

        public DeviceViewForm()
        {
            InitializeComponent();
            Icon = Resources.AppIcon2;
        }

        internal void Start()
        {
            if (Visible)
                Activate();
            else
                Show();
        }

        private void DeviceViewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void DeviceViewForm_Load(object sender, EventArgs e)
        {
            if (DI.Instance.DeviceService == null) return;

            listView1.Items.Clear();
            var devList = DI.Instance.ServerApi.Device();
            foreach (DeviceInfo dev in devList)
            {
                ListViewItem item = new ListViewItem(dev.name);
                item.SubItems.Add((!dev.removed).ToRus());
                item.Tag = dev.id;
                item.BackColor = GetColor(dev?.stand);
                listView1.Items.Add(item);
            }
            listView1.Refresh();
            DeviceViewForm_Resize(null, null);
        }

        private System.Drawing.Color GetColor(string stand)
        {
            switch(stand)
            {
                case "flor1":
                case "ory":
                    return System.Drawing.Color.FromArgb(217, 217, 217);
                case "kes":
                    return System.Drawing.Color.FromArgb(216, 228, 188);
                case "mks":
                    return System.Drawing.Color.FromArgb(184, 204, 228);
                case "bks":
                    return System.Drawing.Color.FromArgb(252, 213, 180);
                case "snim":
                    return System.Drawing.Color.FromArgb(230, 184, 183);
                default:
                    return System.Drawing.Color.White;
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems != null && listView1.SelectedItems.Count > 0)
            {
                var item = listView1.SelectedItems[0];
                int deviceId = (int)item.Tag;
                var device = DI.Instance.ServerApi.DeviceSingle(deviceId);
                var controller = DI.Instance.DeviceService[deviceId];

                DeviceEditorForm form = new DeviceEditorForm();
                form.Device = device;
                form.TopMost = true;
                form.StartPosition = FormStartPosition.CenterParent;
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        form.Save(device.config, controller);
                        DI.Instance.ServerApi.DeviceConfig(device.id, device.config);

                        item.SubItems.Clear();
                        item.Text = device.name;
                        item.SubItems.Add((!controller.Removed).ToRus());
                        item.Tag = device.id;
                        item.BackColor = GetColor(device?.stand);
                        listView1.Refresh();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        form.Close();
                    }
                }
            }
        }

        private void DeviceViewForm_Resize(object sender, EventArgs e)
        {
            columnHeader1.Width = Math.Max(600, listView1.Width - columnHeader2.Width - SystemInformation.VerticalScrollBarWidth - 4);
        }
    }
}
