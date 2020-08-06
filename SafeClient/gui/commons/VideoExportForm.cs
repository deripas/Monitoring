using model.video;
using System;
using System.IO;
using System.Windows.Forms;

namespace gui
{
    public partial class VideoExportForm : Form
    {
        public static VideoExportForm Instance = new VideoExportForm();

        private VideoFileModel video;
        private VideoFileDownloader downloader;

        public VideoExportForm()
        {
            InitializeComponent();
            downloader = new VideoFileDownloader();
            progressBar1.Maximum = 100;

            var dir = Directory.CreateDirectory("save");
            saveFileDialog1.InitialDirectory = dir.FullName;
            saveFileDialog1.DefaultExt = ".avi";
            saveFileDialog1.Filter = "Avi|*.avi|H264|*.h264";
        }

        private void UpdateButton()
        {
            if (!timer1.Enabled)
                buttonSelect.Text = "💾";
            else
                buttonSelect.Text = "🗙";

            dateTimeFromDate.Enabled = !timer1.Enabled;
            dateTimeFromTime.Enabled = !timer1.Enabled;
            dateTimeToDate.Enabled = !timer1.Enabled;
            dateTimeToTime.Enabled = !timer1.Enabled;
        }

        private void buttonSelect_Click(object sender, System.EventArgs e)
        {
            if (video == null) return;
            if(timer1.Enabled)
            {
                Cancel();
                UpdateButton();
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
                video.Camera.Name, 
                from.Day, from.Month, from.Year,
                from.Hour, from.Minute, from.Second);

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var percent = downloader.Start(video, from, to);
                if (percent >= 0)
                {
                    toolStripStatusLabel1.Text = "Загрузка...";
                    progressBar1.Maximum = percent + 1;
                    timer1.Start();
                    UpdateButton();
                }
                else
                {
                    toolStripStatusLabel1.Text = "Ошибка";
                    downloader.Stop();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var pos = downloader.GetPos();
            if (pos >= 0 && pos < 100)
                progressBar1.Value = Math.Min(pos + 1, progressBar1.Maximum);
            else
            {
                Cancel();

                if (pos == 100)
                {
                    progressBar1.Value = progressBar1.Maximum;
                    toolStripStatusLabel1.Text =  "Загрузка завершена";

                    if (!downloader.MoveTo(saveFileDialog1.FileName))
                        toolStripStatusLabel1.Text = "Ошибка копирования";

                    MessageBox.Show("Загрузка завершена");
                    progressBar1.Value = 0;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Ошибка загрузки";
                    progressBar1.Value = 0;
                }
                UpdateButton();
            }
        }

        private void VideoExportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void Cancel()
        {
            downloader.Stop();
            timer1.Stop();
        }

        internal void Start(VideoFileModel select)
        {
            if (timer1.Enabled)
            {
                MessageBox.Show("Предыдущая загрузка не завершена");
            }
            else
            {
                Text = select.Camera.Name;
                video = select;

                dateTimeFromDate.Value = select.BeginTime;
                dateTimeFromTime.Value = select.BeginTime;
                dateTimeToDate.Value = select.EndTime;
                dateTimeToTime.Value = select.EndTime;
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
