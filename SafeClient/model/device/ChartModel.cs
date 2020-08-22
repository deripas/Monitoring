using System;
using System.Collections.Generic;

namespace model.device
{
    public class ChartModel
    {
        public List<DateTime> X { get; set; }
        public List<double> Y { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public DateTime Alert { get; set; }
    }
}
