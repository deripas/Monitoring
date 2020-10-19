using model.video;
using System;
using System.IO;
using System.Windows.Forms;
using NetSDKCS;
using Properties;

namespace gui
{
    public partial class VideoExportForm : Form
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        private const int DOWNLOAD_END = -1;
        private const int DOWNLOAD_FAILED = -2;
        private static fTimeDownLoadPosCallBack m_DownloadPosCallBack;

        
        public static VideoExportForm Instance = new VideoExportForm();

        private VideoPlayBackSource video;
        private Action<string, DateTime, DateTime> callback;
        private IntPtr m_DownloadID;

        public VideoExportForm()
        {
            InitializeComponent();
            Icon = Resources.AppIcon2;
            progressBar1.Maximum = 100;

            var dir = Directory.CreateDirectory("save");
            saveFileDialog1.InitialDirectory = dir.FullName;
            saveFileDialog1.DefaultExt = ".dav";
            saveFileDialog1.Filter = "|*.dav";
            
            m_DownloadPosCallBack = new fTimeDownLoadPosCallBack(DownLoadPosCallBack);
        }

        private void UpdateButton(bool ready)
        {
            if (ready)
                buttonSelect.Text = "💾";
            else
                buttonSelect.Text = "🗙";

            dateTimeFromDate.Enabled = ready;
            dateTimeFromTime.Enabled = ready;
            dateTimeToDate.Enabled = ready;
            dateTimeToTime.Enabled = ready;
        }

        private void buttonSelect_Click(object sender, System.EventArgs e)
        {
            if (video == null) return;
            if (m_DownloadID != IntPtr.Zero)
            {
                Cancel();
                UpdateButton(true);
                toolStripStatusLabel1.Text = "Отменено";
                progressBar1.Value = 0;
                return;
            }

            DateTime from = dateTimeFromDate.Value.Date + dateTimeFromTime.Value.TimeOfDay;
            DateTime to = dateTimeToDate.Value.Date + dateTimeToTime.Value.TimeOfDay;
            if(from > to)
            {
                MessageBox.Show("Ошибка в диапазоне времени");
                return;
            }

            saveFileDialog1.FileName = string.Format("{0}_{1}-{2}-{3}_{4}{5}{6}",
                video.Name, 
                from.Day, from.Month, from.Year,
                from.Hour, from.Minute, from.Second);

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                m_DownloadID = video.Export(saveFileDialog1.FileName, from, to, m_DownloadPosCallBack);
                if (IntPtr.Zero == m_DownloadID)
                {
                    saveFileDialog1.Dispose();
                    toolStripStatusLabel1.Text = "Ошибка";
                    MessageBox.Show(this, NETClient.GetLastError());
                    return;
                }

                toolStripStatusLabel1.Text = "Выгрузка...";
                progressBar1.Value = 0;
                progressBar1.Maximum = 100;
                UpdateButton(false);
            }
        }
        
        private void DownLoadPosCallBack(IntPtr lPlayHandle, uint dwTotalSize, uint dwDownLoadSize, int index, NET_RECORDFILE_INFO recordfileinfo, IntPtr dwUser)
        {
            if (lPlayHandle == m_DownloadID)
            {
                int value = 0;
                if (DOWNLOAD_END == (int)dwDownLoadSize)
                {
                    value = DOWNLOAD_END;
                }
                else if (DOWNLOAD_FAILED == (int)dwDownLoadSize)
                {
                    value = DOWNLOAD_FAILED;
                }
                else
                {
                    if (dwDownLoadSize >= dwTotalSize)
                    {
                        value = 100;
                    }
                    else
                    {
                        value = (int)(dwDownLoadSize * 100 / dwTotalSize);
                    }
                }
                this.BeginInvoke((Action<int>)UpdateProgressBarUI, value);
            }
        }
        
        private void UpdateProgressBarUI(int value)
        {
            if (m_DownloadID != IntPtr.Zero)
            {
                if (DOWNLOAD_END == value)
                {
                    progressBar1.Value = 100;
                    Cancel();

                    DateTime from = dateTimeFromDate.Value.Date + dateTimeFromTime.Value.TimeOfDay;
                    DateTime to = dateTimeToDate.Value.Date + dateTimeToTime.Value.TimeOfDay;
                    callback.Invoke(saveFileDialog1.FileName, from, to);

                    MessageBox.Show(this, "Выгрузка завершена");
                    toolStripStatusLabel1.Text = "Выгрузка завершена";
                    UpdateButton(true);
                    progressBar1.Value = 0;
                    return;
                }
                if (DOWNLOAD_FAILED == value)
                {
                    MessageBox.Show(this, "Ошибка выгрузки");
                    toolStripStatusLabel1.Text = "Ошибка выгрузки";
                    UpdateButton(true);
                    return;
                }
                progressBar1.Value = value;
            }
        }


        private void VideoExportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void Cancel()
        {
            if (m_DownloadID != IntPtr.Zero)
            {
                Log.Info("NETClient.StopDownload - {0}",  NETClient.StopDownload(m_DownloadID));
                m_DownloadID = IntPtr.Zero;
            }
        }

        internal void Start(VideoPlayBackSource select, Action<string, DateTime, DateTime> callback)
        {
            if (m_DownloadID != IntPtr.Zero)
            {
                MessageBox.Show("Предыдущая выгрузка не завершена");
            }
            else
            {
                Text = select.Name;
                video = select;
                this.callback = callback;

                dateTimeFromDate.Value = select.BeginTime;
                dateTimeFromTime.Value = select.BeginTime;
                dateTimeToDate.Value = select.EndTime;
                dateTimeToTime.Value = select.EndTime;
                toolStripStatusLabel1.Text = "Выбeрите файл";
            }

            if (Visible)
                Activate();
            else
                Show();
        }

        public new void Dispose()
        {
            Cancel();
            base.Dispose();
        }
    }

}
