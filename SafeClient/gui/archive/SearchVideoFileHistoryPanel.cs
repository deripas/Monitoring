using System;
using System.Windows.Forms;
using model.camera;
using model.video;
using NetSDKCS;
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
            videoFileList1.RefreshList += Search;
        }

        internal void Start(CameraController cam)
        {
            var cameras = DI.Instance.CameraService.CameraList;
            cameraComboBox.Items.Clear();
            cameraComboBox.Items.AddRange(cameras.ToArray());
        }

        internal void NextItem()
        {
            videoFileList1.NextItem();
        }

        private void Search()
        {
            var cam = (CameraController)cameraComboBox.SelectedItem;
            if (cam == null) return;

            var video = cam.SearchVideoFiles(dateTimePicker1.Value.Date, EM_QUERY_RECORD_TYPE.ALL);
            videoFileList1.Items = video;
        }

        private void cameraComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Search();
        }
    }
}
