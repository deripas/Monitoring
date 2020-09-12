using ltrModulesNet;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using SafeServer.dto;
using SafeServer.ltr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SafeServer.service
{
    public class LtrService
    {
        private Dictionary<Slot, ILtr> map;

        public LtrService()
        {
            map = new Dictionary<Slot, ILtr>();
            foreach (var ltr in Ltr())
            {
                var slot = new Slot { sn = ltr.Sn, num = ltr.Num };
                map.Add(slot, create(slot, ltr.Type));
            }
        }

        private ILtr create(Slot slot, string type)
        {
            if (type.ToLower().Equals("ltr41"))
                return new Ltr41(slot);
            if (type.ToLower().Equals("ltr42"))
                return new Ltr42(slot);
            if (type.ToLower().Equals("ltr27"))
                return new Ltr27(slot);
            if (type.ToLower().Equals("ltr25"))
                return new Ltr25(slot);

            throw new Exception("unknown type " + type);
        }

        internal T GetLtr<T>(Slot slot)
        {
            return (T)map[slot];
        }

        private IEnumerable<LTR> Ltr()
        {
            using var db = new DatabaseService();
            return db.LTR.ToList();
        }

        public void Start()
        {
            foreach (var ltr in map.Values)
                ltr.Start();
        }

        internal void Dispose()
        {
            foreach (var ltr in map.Values)
                ltr.Stop();

            _LTRNative.TLTR LTR = _LTRNative.NewLTR;
            LTR.cc = 0;
            LTR_ServerRestart(ref LTR);
        }

        [DllImport("ltrapi.dll")]
        public static extern ltrModulesNet._LTRNative.LTRERROR LTR_ServerRestart(ref _LTRNative.TLTR ltr);

    }
}
