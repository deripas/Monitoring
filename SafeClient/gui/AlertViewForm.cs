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
            searchAlertPanel1.SelectItem += SearchAlertPanel1_SelectItem;
        }

        private void SearchAlertPanel1_SelectItem(AlertModel alert)
        {
            DateTime from = DateTime.Now.AddHours(-3);
            DateTime to = DateTime.Now.AddHours(-3).AddMinutes(5);

            alertPlayerPanel1.SelectVideo(alert.Video(from, to));
            alertPlayerPanel1.SelectChart(alert.Chart(from, to));
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
