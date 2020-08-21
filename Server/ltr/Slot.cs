using System;

namespace SafeServer.ltr
{
    public class Slot
    {
        public string sn { get; set; }
        public int num { get; set; }

        public override string ToString()
        {
            return $"{sn}:{num}";
        }

        public char[] ToCharArraySn()
        {
            var array = new char[16];
            sn.CopyTo(0, array, 0, Math.Min(sn.Length, array.Length));
            return array;
        }

        public override bool Equals(object obj)
        {
            return obj is Slot slot &&
                   sn == slot.sn &&
                   num == slot.num;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(sn, num);
        }
    }
}
