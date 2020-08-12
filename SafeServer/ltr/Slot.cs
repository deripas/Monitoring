using System;

namespace SafeServer.ltr
{
    public class Slot
    {
        public string Sn { get; set; }
        public int Num { get; set; }

        public char[] ToCharArraySn()
        {
            var sn = new char[16];
            Sn.CopyTo(0, sn, 0, Math.Min(Sn.Length, sn.Length));
            return sn;
        }
    }
}
