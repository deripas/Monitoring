using gui.component;
using model.camera;
using model.video;
using service;
using System;
using System.Windows.Forms;

namespace gui
{
    public partial class VideoViewForm : Form
    {
        public static VideoViewForm Instance = new VideoViewForm();

        public VideoViewForm()
        {
            InitializeComponent();
        }

        private void VideoViewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            videoPlayerPanel1.Stop();
            Hide();
        }

        internal void Start()
        {
            Start(null);
        }

        internal void Start(CameraController cam)
        {
            var cameras = DI.Instance.CameraService.CameraList;
            cameraComboBox.Items.Clear();
            cameraComboBox.Items.AddRange(cameras.ToArray());
            cameraComboBox.SelectedItem = cam ?? cameras[0];

            if (Visible)
                Activate();
            else
                Show();
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            var cam = (CameraController) cameraComboBox.SelectedItem;
            FileAlertType type = calcFileType();
            var video = cam.SearchVideo(dateTimePicker1.Value.Date, type);
            if(video.Count == 0)
            {
                MessageBox.Show("not found");
                return;
            }
            listBox1.Items.Clear();
            listBox1.Items.AddRange(video.ToArray());
        }

        private FileAlertType calcFileType()
        {
            FileAlertType type = FileAlertType.None;
            if (alarmCheckBox.Checked)
                type |= FileAlertType.Alarm;
            if (regularCheckBox.Checked)
                type |= FileAlertType.Regular;
            if (detectCheckBox.Checked)
                type |= FileAlertType.Detect;
            if (manualCheckBox.Checked)
                type |= FileAlertType.Manual;
            return type;
        }

        private void VideoViewForm_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var select = listBox1.SelectedItem;
            if(select != null)
            {
                videoPlayerPanel1.Start((VideoFileModel) select);
            }
        }
    }
}
