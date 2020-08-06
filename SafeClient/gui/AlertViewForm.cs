using api;
using model.device;
using model.video;
using Properties;
using System;
using System.Windows.Forms;

namespace gui
{
    public partial class AlertViewForm : Form
    {
        public static AlertViewForm Instance = new AlertViewForm();

        public AlertViewForm()
        {
            InitializeComponent();
            Icon = Resources.AppIcon;
            searchAlertPanel1.SelectVideoItem += SearchAlertPanel1_SelectVideoItem;
            searchAlertPanel1.PlayVideoItem += SearchAlertPanel1_PlayVideoItem;
            searchAlertPanel1.StopVideoItem += SearchAlertPanel1_StopVideoItem;
            alertPlayerPanel1.NextFile += AlertPlayerPanel1_NextFile;
        }

        private void SearchAlertPanel1_StopVideoItem()
        {
            alertPlayerPanel1.Stop();
        }

        private void SearchAlertPanel1_PlayVideoItem()
        {
            alertPlayerPanel1.Start();
        }

        private void AlertPlayerPanel1_NextFile()
        {
            searchAlertPanel1.NextVideoItem();
        }

        private void SearchAlertPanel1_SelectVideoItem(VideoFileModel video)
        {
            var alert = searchAlertPanel1.Alert;
            if (alert == null) return;

            alertPlayerPanel1.SelectVideo(video);
            alertPlayerPanel1.SelectChart(alert.Chart(video.BeginTime, video.EndTime));
        }

        internal void Start()
        {
            if (Visible)
                Activate();
            else
                Show();
        }

        private void AlertViewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            alertPlayerPanel1.Stop();
            Hide();
        }
    }
}
