using gui.device;
using model.device;
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
            var devList = DI.Instance.DeviceService.DeviceList;
            foreach (DeviceController dev in devList)
            {
                ListViewItem item = new ListViewItem(dev.Name);
                item.SubItems.Add(dev.Enable.ToString());
                item.Tag = dev;
                item.BackColor = GetColor(dev?.Camera?.Stand);
                listView1.Items.Add(item);
            }
            listView1.Refresh();
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
                DeviceController dev = (DeviceController)listView1.SelectedItems[0].Tag;
                DeviceEditorForm form = new DeviceEditorForm();
                form.Device = dev;
                form.TopMost = true;
                form.StartPosition = FormStartPosition.CenterParent;
                if (form.ShowDialog(this) == DialogResult.OK)
                {

                }
            }
        }
    }
}
