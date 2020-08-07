using model.device;
using model.video;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace gui
{
    public partial class AlertPlayerPanel : UserControl, IVideoPlayerView
    {
        public double Ratio
        {
            get
            {
                return canvasPanel1.Ratio;
            }
            set
            {
                canvasPanel1.Ratio = value;
            }
        }

        public PictureBox Canvas
        {
            get
            {
                return canvasPanel1.Canvas;
            }
        }

        public event Action NextFile
        {
            add
            {
                playerNavigationPanel1.NextFile += value;
            }
            remove
            {
                playerNavigationPanel1.NextFile -= value;
            }
        }

        private ChartArea ChartArea
        {
            get
            {
                return chart1.ChartAreas[0];
            }
        }

        private Series Series
        {
            get
            {
                return chart1.Series[0];
            }
        }

        private ChartModel chart;

        public AlertPlayerPanel()
        {
            InitializeComponent();
            playerNavigationPanel1.VisibleTrackBar = false;
            playerNavigationPanel1.StatusText += PlayerNavigationPanel1_StatusText;
            playerNavigationPanel1.ProgressChange += PlayerNavigationPanel1_ProgressChange;
        }

        internal void SelectVideo(VideoPlayBackSource video)
        {
            playerNavigationPanel1.VideoPlayer = new VideoFilePlayer(this, video);
        }

        private void PlayerNavigationPanel1_ProgressChange(double pos)
        {
            if (chart == null) return;

            double millis = (chart.To - chart.From).TotalMilliseconds;
            var time = chart.From.AddMilliseconds(millis * pos);
            ChartArea.CursorX.Position = time.ToOADate();
        }

        private void PlayerNavigationPanel1_StatusText(string text)
        {
            speedLabel.Text = text;
        }

        internal void SelectChart(ChartModel chart)
        {
            this.chart = chart;
            chart1.Annotations.Clear();
            Series.Points.Clear();

            var alert = new VerticalLineAnnotation();
            alert.Name = "alert";
            alert.AxisX = ChartArea.AxisX;
            alert.ClipToChartArea = ChartArea.Name;
            alert.IsInfinitive = true;
            alert.LineColor = Color.Red;
            alert.LineWidth = 2;
            alert.X = chart.Alert.ToOADate();
            chart1.Annotations.Add(alert);

            Series.Points.DataBindXY(chart.X, chart.Y);
        }

        internal void Start()
        {
            playerNavigationPanel1.Start();
        }

        internal void Stop()
        {
            playerNavigationPanel1.Stop();
        }

        private void chart1_MouseDown(object sender, MouseEventArgs e)
        {
            if (chart == null) return;

            var time = ChartArea.AxisX.PixelPositionToValue(e.Location.X);
            var range = (chart.To - chart.From).TotalMilliseconds;
            var dt = (DateTime.FromOADate(time) - chart.From).TotalMilliseconds;
            ChartArea.CursorX.Position = time;
            playerNavigationPanel1.ScrollToPos(dt / range);
        }
    }
}
