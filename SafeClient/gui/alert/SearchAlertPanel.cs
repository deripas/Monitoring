using System;
using System.Windows.Forms;
using service;
using model.device;
using model.video;
using System.Configuration;
using System.Drawing;
using System.Collections.Generic;
using NetSDKCS;
using System.Text;
using System.IO;
using System.Globalization;

namespace gui
{
    public partial class SearchAlertPanel : UserControl
    {
        public event Action PlayVideoItem;
        public event Action StopVideoItem;
        public event Action<VideoPlayBackSource> SelectVideoItem;

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
        private long selectAlertId = -1;

        internal void NextVideoItem()
        {
            if (alertListView.SelectedIndices != null && alertListView.SelectedIndices.Count == 1)
            {
                var sel = alertListView.SelectedIndices[0];
                if (sel >= 0 && sel < alertListView.Items.Count -1)
                {
                    alertListView.Items[sel].Selected = false;
                    alertListView.Items[sel + 1].Selected = true;
                    alertListView.Select();
                    PlayVideoItem?.Invoke();
                }
            }
        }

        public SearchAlertPanel()
        {
            InitializeComponent();
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            dateTimePicker1.Value = DateTime.Now.Date;
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
            ListViewItem select = null;
            foreach (AlertModel alert in alerts)
            {
                ListViewItem item = new ListViewItem(alert.Device.Name);
                item.SubItems.Add(String.Format("{0:HH:mm:ss}", alert.Time));
                item.SubItems.Add(alert.Processed.ToRus());
                item.Tag = alert;
                alertListView.Items.Add(item);

                if(selectAlertId == alert.ID)
                    select = item;
                
            }
            alertListView.Refresh();
            
            if(select != null)
            {
                select.Selected = true;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Search();
        }

        private bool SelectAlert()
        {
            var alert = Alert;
            if (alert == null) return false;

            SelectVideoItem.Invoke(alert.Video());
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
            if (count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Найдено " + count + " тревог", "Внимание", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DI.Instance.ServerApi.ProcessAlertAll(alert.ID);
                    Search();
                }
            }
            else
            {
                MessageBox.Show("Тревог не найдено", "Внимание", MessageBoxButtons.OK);
            }
        }

        private void applyListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var alert = Alert;
            if (alert == null) return;

            DI.Instance.ServerApi.ProcessAlert(alert.ID);
            alert.Processed = true;
            SetAlertList(alertsList);
        }

        private void alertListView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (alertListView.FocusedItem.Bounds.Contains(e.Location))
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void alertListView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Alert == null)
                {
                    contextMenuStrip2.Show(Cursor.Position);
                }
            }
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var alert = DI.Instance.ServerApi.FindLastAlert(false);
            if(alert.id > 0)
            {
                selectAlertId = alert.id;
                dateTimePicker1.Value = alert.GetDateTime();
                //if(comboBoxDevice.SelectedItem == null)
                {
                    comboBoxDevice.SelectedItem = DI.Instance.DeviceService[alert.device];
                }
            }
        }

        private void alertListView_DoubleClick(object sender, EventArgs e)
        {
            if (SelectAlert())
                PlayVideoItem?.Invoke();
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            //StopVideoItem?.Invoke();
            var alert = Alert;
            if (alert == null) return;

            VideoExportForm.Instance.Start(alert.Video(), (path, from, to) =>
            {
                try
                {
                    var chart = DI.Instance.DeviceService.Chart(alert, from, to);
                    var x = chart.X;
                    var y = chart.Y;

                    var csv = new StringBuilder();
                    for (int i = 0; i < x.Count; i++)
                    {
                        var newLine = string.Format("{0};{1};{2:0.00000}", x[i].ToShortDateString(),x[i].ToLongTimeString(), y[i]);
                        csv.AppendLine(newLine);
                    }

                    var dir = Path.GetDirectoryName(path);
                    var file = Path.GetFileNameWithoutExtension(path) + ".scv";
                    var full = Path.Combine(dir, file);
                    File.WriteAllText(full, csv.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Ошибка сохранения CSV");
                }
            });
        }

        private void toLastAlertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var alert = DI.Instance.ServerApi.FindLastAlert();
            if (alert.id > 0)
            {
                selectAlertId = alert.id;
                dateTimePicker1.Value = alert.GetDateTime();
                //if (comboBoxDevice.SelectedItem == null)
                {
                    comboBoxDevice.SelectedItem = DI.Instance.DeviceService[alert.device];
                }
            }
        }
    }
}
