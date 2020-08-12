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
    }
}
