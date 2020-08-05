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

        public event Action<VideoFileModel> SelectItem
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

        public event Action PlayItem
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

        public event Action StopItem
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
            videoFileList1.NextItem();
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

        private void findButton_Click(object sender, System.EventArgs e)
        {
            var cam = (CameraController)cameraComboBox.SelectedItem;
            FileAlertType type = calcFileType();
            var video = cam.SearchVideoFiles(dateTimePicker1.Value.Date, type);
            if (video.Count == 0)
            {
                MessageBox.Show("not found");
                return;
            }
            videoFileList1.Items = video;
        }
    }
}
