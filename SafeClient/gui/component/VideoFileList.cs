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
                if (value.Count == 0)
                {
                    listBox1.Items.Clear();
                    return;
                }
                if (listBox1.Items.Count == 0)
                {
                    listBox1.Items.AddRange(value.ToArray());
                    return;
                }

                if (listBox1.Items.Count > value.Count)
                {
                    listBox1.Items.Clear();
                    listBox1.Items.AddRange(value.ToArray());
                    return;
                }

                if (listBox1.Items[0].ToString().Equals(value[0].ToString()))
                {
                    // merge case
                    var i = 0;
                    while (i < listBox1.Items.Count
                        && listBox1.Items[i].ToString().Equals(value[i].ToString()))
                    { 
                        i++;
                    }

                    while (i < listBox1.Items.Count)
                    {
                        listBox1.Items[i] = value[i];
                        i++;
                    }

                    var n = value.Count - i;
                    if (n > 0)
                    {
                        listBox1.Items.AddRange(value.GetRange(i, n).ToArray());
                    }

                }
                else
                {
                    listBox1.Items.Clear();
                    listBox1.Items.AddRange(value.ToArray());
                }
            }
        }

        public VideoFileModel this[int index]
        {
            get
            {
                var o = listBox1.Items[index];
                if (o is VideoFileModel)
                    return (VideoFileModel)o;
                else
                    return null;
            }
        }

        public event DrawItemEventHandler DrawItem
        {
            add
            {
                listBox1.DrawMode = DrawMode.OwnerDrawFixed;
                listBox1.DrawItem += value;
            }
            remove
            {
                listBox1.DrawItem -= value;
            }
        }

        public event Action<VideoFileModel> SelectItem;
        public event Action PlayItem;
        public event Action StopItem;
        public event Action RefreshList;

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

        internal void SelectByTime(DateTime time)
        {
            for(int i = 0; i < listBox1.Items.Count; i ++)
            {
                VideoFileModel item = (VideoFileModel)listBox1.Items[i];
                if (item.BeginTime <= time && time <= item.EndTime)
                {
                    listBox1.SelectedIndex = i;
                    break;
                }
            }
            SelectVideoFile();
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            //StopItem?.Invoke();
            var select = listBox1.SelectedItem;
            if (select == null) return;

            VideoExportForm.Instance.Start((VideoFileModel)select, (path, f, t) => { });
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshList?.Invoke();
        }
    }
}
