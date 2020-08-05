using System;
using System.Windows.Forms;
using service;
using model.device;

namespace gui
{
    public partial class SearchAlertPanel : UserControl
    {
        public DateTime DateTime
        {
            get
            {
                return dateTimePicker1.Value;
            }
        }

        public event Action<AlertModel> SelectItem;

        public SearchAlertPanel()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Now;
        }

        public void Search()
        {
            var alerts = DI.Instance.DeviceService.FindAlerts(dateTimePicker1.Value);
            listBox1.Items.Clear();
            listBox1.Items.AddRange(alerts.ToArray());
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectAlert();
        }

        private bool SelectAlert()
        {
            var select = listBox1.SelectedItem;
            if (select == null) return false;

            SelectItem?.Invoke((AlertModel)select);
            return true;
        }
    }
}
