using model.video;
using System;
using System.IO;
using System.Windows.Forms;

namespace gui
{
    public partial class VideoExportForm : Form
    {
        private VideoFileModel video;
        private VideoFileDownloader downloader;

        public VideoExportForm()
        {
            InitializeComponent();
            downloader = new VideoFileDownloader();
            progressBar1.Maximum = 100;
            saveFileDialog1.DefaultExt = ".h264";
            saveFileDialog1.Filter = "H264|*.h264|Avi|*.avi";
        }

        private void UpdateButton()
        {
            if (!timer1.Enabled)
                buttonSelect.Text = "💾";
            else
                buttonSelect.Text = "🗙";
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

            saveFileDialog1.FileName = string.Format("{0}_{1}-{2}-{3}_{4}{5}{6}",
                video.camera.Name, 
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

        internal DialogResult ShowDialog(VideoFileModel select)
        {
            video = select;
            dateTimeFromDate.Value = select.BeginTime;
            dateTimeFromTime.Value = select.BeginTime;
            dateTimeToDate.Value = select.EndTime;
            dateTimeToTime.Value = select.EndTime;
            return ShowDialog();
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

        private void VideoExportForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cancel();
            downloader.Dispose();
        }

        private void Cancel()
        {
            downloader.Stop();
            timer1.Stop();
        }
    }
}
