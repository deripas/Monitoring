using api.dto;
using model.camera;
using model.video;
using System;
using SDK_HANDLE = System.Int32;

namespace model.device
{
    public class AlertModel
    {
        public DateTime Time
        {
            get
            {
                return info.Time;
            }
        }
        public CameraController Camera;
        private AlertInfo info;

        public AlertModel(CameraController camera, AlertInfo info)
        {
            this.Camera = camera;
            this.info = info;
        }

        public override string ToString()
        {
            return String.Format("alert [{0:HH:mm:ss}]", Time);
        }

        internal VideoTimeRangeModel Video(DateTime from, DateTime to)
        {
            return Camera.SearchVideo(from, to);
        }

        internal ChartModel Chart(DateTime from, DateTime to)
        {
            int n = 1000;
            DateTime[] x = new DateTime[n];
            double[] y = new double[n];
            double millis = (to - from).TotalMilliseconds / n;
            for (int i = 0; i < n; i++)
            {
                x[i] = from.AddMilliseconds(i * millis);
                y[i] = Math.Sin((double)i * Math.PI * 2 / n);
            }

            var chart = new ChartModel();
            chart.X = x;
            chart.Y = y;
            chart.From = from;
            chart.To = to;
            chart.Alert = Time;
            return chart;
        }
    }
}
