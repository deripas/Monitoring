using System;
using System.Windows.Forms;
using service;
using model.device;
using model.video;
using System.Configuration;

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
                if (listBox1.SelectedItem is AlertModel)
                    return (AlertModel)listBox1.SelectedItem;
                else
                    return null;
            }
        }

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

            //if(video.BeginTime <= alert.Time && alert.Time <= video.EndTime)
        }

        public void Search()
        {
            if (DI.Instance.DeviceService == null) return;

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
    }
}
