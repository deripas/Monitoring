using System;

namespace model.device
{
    public class ChartModel
    {
        public DateTime[] X { get; set; }
        public double[] Y { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public DateTime Alert { get; set; }
    }
}
