using api.dto;
using model.camera;
using model.video;
using System;
using SDK_HANDLE = System.Int32;

namespace model.device
{
    public class AlertModel
    {
        public CameraController camera;

        public AlertModel(CameraController camera)
        {
            this.camera = camera;
        }

        public override string ToString()
        {
            return "alert";
        }

        internal VideoTimeRangeModel Video(DateTime from, DateTime to)
        {
            return camera.SearchVideo(from, to);
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
                y[i] = i;
            }

            var chart = new ChartModel();
            chart.X = x;
            chart.Y = y;
            chart.From = from;
            chart.To = to;
            chart.Alert = from.AddMinutes(4);
            return chart;
        }
    }
}
