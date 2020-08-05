using System;
using System.Collections.Generic;
using System.Windows.Forms;
using model.video;

namespace gui
{
    public partial class VideoFileList : UserControl
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        public List<VideoFileModel> Items
        {
            set
            {
                listBox1.Items.Clear();
                listBox1.Items.AddRange(value.ToArray());
            }
        }

        public event Action<VideoFileModel> SelectItem;
        public event Action PlayItem;
        public event Action StopItem;

        public VideoFileList()
        {
            InitializeComponent();
            buttonExport.Enabled = false;
        }

        internal void NextItem()
        {
            var index = listBox1.SelectedIndex;
            if (index + 1 >= listBox1.Items.Count) return;

            Log.Info("try play next file...", this);
            listBox1.SelectedIndex = index + 1;
            listBox1_DoubleClick(null, null);
        }

        private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            buttonExport.Enabled = SelectVideoFile();
        }

        private void listBox1_DoubleClick(object sender, System.EventArgs e)
        {
            if (SelectVideoFile())
                PlayItem?.Invoke();
        }

        private bool SelectVideoFile()
        {
            var select = listBox1.SelectedItem;
            if (select == null) return false;

            SelectItem?.Invoke((VideoFileModel)select);
            return true;
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            StopItem?.Invoke();
            var select = listBox1.SelectedItem;
            if (select == null) return;

            VideoExportForm export = new VideoExportForm();
            if(export.ShowDialog((VideoFileModel)select) == DialogResult.OK)
            {

            }
        }
    }
}
