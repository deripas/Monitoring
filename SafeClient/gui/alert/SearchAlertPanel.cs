using System;
using System.Windows.Forms;
using service;
using model.device;
using model.video;
using System.Configuration;
using System.Drawing;
using System.Collections.Generic;

namespace gui
{
    public partial class SearchAlertPanel : UserControl
    {
        public event Action PlayVideoItem
        {
            add
            {
                videoFileList1.PlayItem += value;
            }
            remove
            {
                videoFileList1.PlayItem -= value;
            }
        }

        public event Action StopVideoItem
        {
            add
            {
                videoFileList1.StopItem += value;
            }
            remove
            {
                videoFileList1.StopItem -= value;
            }
        }

        public event Action<VideoFileModel> SelectVideoItem
        {
            add
            {
                videoFileList1.SelectItem += value;
            }
            remove
            {
                videoFileList1.SelectItem -= value;
            }
        }

        public AlertModel Alert
        {
            get
            {
                if (alertListView.SelectedItems != null && alertListView.SelectedItems.Count == 1)
                {
                    var sel = alertListView.SelectedItems[0];
                    return (AlertModel)sel.Tag;
                }
                return null;
            }
        }

        private List<AlertModel> alertsList;

        internal void NextVideoItem()
        {
            videoFileList1.NextItem();
        }

        public SearchAlertPanel()
        {
            InitializeComponent();
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            dateTimePicker1.Value = DateTime.Now.Date;
            videoFileList1.DrawItem += VideoFileList1_DrawItem;
        }

        private void VideoFileList1_DrawItem(object sender, DrawItemEventArgs e)
        {
            var alert = Alert;
            if (alert == null) return;

            var video = videoFileList1[e.Index];
            if (video == null) return;

            try
            {
                e.DrawBackground();
                if (e.State.HasFlag(DrawItemState.Selected))
                {
                    e.Graphics.DrawString(video.ToString(), e.Font, Brushes.White, e.Bounds, StringFormat.GenericDefault);
                }
                else
                {
                    if (video.BeginTime <= alert.Time && alert.Time <= video.EndTime)
                    {
                        e.Graphics.FillRectangle(Brushes.Red, e.Bounds);
                        e.Graphics.DrawString(video.ToString(), e.Font, Brushes.White, e.Bounds, StringFormat.GenericDefault);
                    }
                    else
                    {
                        e.Graphics.DrawString(video.ToString(), e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
                    }
                }
                e.DrawFocusRectangle();
            }
            catch
            {

            }
        }

        public void Search()
        {
            try
            {
                if (DI.Instance.DeviceService == null) return;
                if (comboBoxDevice.SelectedItem == null) return;
                if (dateTimePicker1.Value == null) return;

                var from = dateTimePicker1.Value.Date;
                var to = from.AddDays(1);
                var select = comboBoxDevice.SelectedItem;
                if (select is DeviceController)
                {
                    var dev = (DeviceController)select;
                    var alerts = DI.Instance.DeviceService.FindAlerts(dev.Id, from, to);
                    SetAlertList(alerts);
                }
                else
                {
                    var alerts = DI.Instance.DeviceService.FindAlerts(from, to);
                    SetAlertList(alerts);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetAlertList(List<AlertModel> alerts)
        {
            alertsList = alerts;
            alertListView.Items.Clear();
            foreach (AlertModel alert in alerts)
            {
                ListViewItem item = new ListViewItem(alert.Device.Name);
                item.SubItems.Add(String.Format("{0:HH:mm:ss}", alert.Time));
                item.SubItems.Add(alert.Processed.ToString());
                item.Tag = alert;
                alertListView.Items.Add(item);
            }
            alertListView.Refresh();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Search();
        }

        private bool SelectAlert()
        {
            var alert = Alert;
            if (alert == null) return false;

            int AlertBeforeSec = int.Parse(ConfigurationManager.AppSettings["alert.before.sec"]);
            int AlertAfterSec = int.Parse(ConfigurationManager.AppSettings["alert.after.sec"]);

            var cam = alert.Camera;
            DateTime from = alert.Time.AddSeconds(-AlertBeforeSec);
            DateTime to = alert.Time.AddSeconds(AlertAfterSec);

            videoFileList1.Items = cam.SearchVideoFiles(from, to, api.FileType.SDK_RECORD_ALL);
            videoFileList1.SelectByTime(alert.Time);
            return true;
        }

        private void SearchAlertPanel_Load(object sender, EventArgs e)
        {
            if (DI.Instance.DeviceService == null) return;

            var list = DI.Instance.DeviceService.DeviceList;
            comboBoxDevice.Items.Clear();
            comboBoxDevice.Items.Add("Все");
            comboBoxDevice.Items.AddRange(list.ToArray());
        }

        private void comboBoxDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void alertListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectAlert();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var alert = Alert;
            if (alert == null) return;

            DI.Instance.ServerApi.ProcessAlert(alert.ID);
            alert.Processed = true;
            SetAlertList(alertsList);
        }

        private void applyAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var alert = Alert;
            if (alert == null) return;

            var count = DI.Instance.ServerApi.FindAlertAll(alert.ID).count;
            DialogResult dialogResult = MessageBox.Show("Найдено " + count + " тревог", "Внимание" , MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DI.Instance.ServerApi.ProcessAlertAll(alert.ID);
                Search();
            }
        }
    }
}
