using SafeServer.ltr;
using System;

namespace SafeServer.dto.config
{
    public class Channel
    {
        public string sn { get; set; }
        public int num { get; set; }
        public int index { get; set; }

        public Slot GetSlot()
        {
            return new Slot { sn = sn, num = num };
        }

        public override string ToString()
        {
            return $"{sn}:{num}:{index}";
        }
    }
}
