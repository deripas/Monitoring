using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace api.dto.config
{
    public class Channel
    {
        public string sn { get; set; }
        public int num { get; set; }
        public int index { get; set; }
        public Cfg cfg { get; set; }
    }
}
