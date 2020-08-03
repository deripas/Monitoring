using System;
using System.Windows.Forms;
using model.camera;
using model.video;
using service;

namespace gui
{
    public partial class SearchVideoFileHistoryPanel : UserControl
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        public event Action<VideoFileModel> SelectItem;
        public event Action PlayItem;

        public SearchVideoFileHistoryPanel()
        {
            InitializeComponent();
        }

        internal void Start(CameraController cam)
        {
            var cameras = DI.Instance.CameraService.CameraList;
            cameraComboBox.Items.Clear();
            cameraComboBox.Items.AddRange(cameras.ToArray());
            cameraComboBox.SelectedItem = cam ?? cameras[0];
        }

        internal void NextItem()
        {
            var index = listBox1.SelectedIndex;
            if (index + 1 >= listBox1.Items.Count) return;

            Log.Info("try play next file...", this);
            listBox1.SelectedIndex = index + 1;
            listBox1_DoubleClick(null, null);
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

        private bool SelectVideoFile()
        {
            var select = listBox1.SelectedItem;
            if (select == null) return false;

            SelectItem?.Invoke((VideoFileModel)select);
            return true;
        }

        private void findButton_Click(object sender, System.EventArgs e)
        {
            var cam = (CameraController)cameraComboBox.SelectedItem;
            FileAlertType type = calcFileType();
            var video = cam.SearchVideo(dateTimePicker1.Value.Date, type);
            if (video.Count == 0)
            {
                MessageBox.Show("not found");
                return;
            }
            listBox1.Items.Clear();
            listBox1.Items.AddRange(video.ToArray());
        }

        private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            SelectVideoFile();
        }

        private void listBox1_DoubleClick(object sender, System.EventArgs e)
        {
            if (SelectVideoFile())
                PlayItem?.Invoke();
        }
    }
}
