using gui.device;
using model.device;
using service;
using System;
using System.Windows.Forms;

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
            foreach (DeviceController dev in DI.Instance.DeviceService.DeviceList)
            {
                ListViewItem item = new ListViewItem(dev.Name);
                item.SubItems.Add(dev.Enable.ToString());
                item.Tag = dev;
                listView1.Items.Add(item);
            }
            listView1.Refresh();
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
