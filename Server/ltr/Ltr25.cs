using System;
using System.Reactive.Linq;
using ltrModulesNet;

namespace SafeServer.ltr
{
    public class Ltr25 : LtrRead<Tuple<double[], int>>, ILtr
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        public IObservable<Tuple<double[], int>> this[int index]
        {
            get
            {
                var seed = Tuple.Create(new double[data.Length], 0);
                return Data.Scan(seed, (accum, cur) =>
                {
                    var (inArray, size) = cur;
                    var (outArray, _) = accum;

                    for (int i = 0, k = index; k < size; i++, k += EnabledChCnt)
                        outArray[i] = inArray[k];

                    return Tuple.Create(outArray, size / EnabledChCnt);
                });
            }
        }

        private Slot slot;
        private ltr25api ltr;

        const int EnabledChCnt = 8;
        const int RECV_BLOCK_CH_SIZE = 1024;
        private static ltr25api.DataFormat DataFmt = ltr25api.DataFormat.Format20;
        private static int recv_data_cnt = RECV_BLOCK_CH_SIZE * EnabledChCnt;
        private static int recv_wrd_cnt = recv_data_cnt * (DataFmt == ltr25api.DataFormat.Format20 ? 1 : 2);

        private uint[] rbuf = new uint[recv_wrd_cnt];
        /* метки приходят на кждое слово, а не на отсчет */
        private uint[] marks = new uint[recv_wrd_cnt];
        private double[] data = new double[recv_data_cnt];
        /* признаки обрыва/кз - по одному на каждый канал */
        private ltr25api.ChStatus[] ch_status = new ltr25api.ChStatus[EnabledChCnt];

        public Ltr25(Slot slot)
        {
            this.slot = slot;
            ltr = new ltr25api();
        }

        public new _LTRNative.LTRERROR Start()
        {
            Log.Info("{0} Start", this);
            var error = ltr.Open(slot.sn, slot.num);
            if(error != _LTRNative.LTRERROR.OK)
            {
                Log.Error("{0} Open", this);
                return error;
            }    
            
            var cfg = ltr.Cfg;
            cfg.DataFmt = DataFmt;
            cfg.FreqCode = ltr25api.FreqCode.Freq_2K4;
            cfg.ISrcValue = ltr25api.ISrcValues.I_10;

            for (var i = 0; i < EnabledChCnt; i++)
                cfg.Ch[i].Enabled = true;
  
            ltr.Cfg = cfg;
            error = ltr.SetADC();
            if(error != _LTRNative.LTRERROR.OK)
            {
                Log.Error("{0} SetADC", this);
                return error;
            }    
            
            error = ltr.Start();
            if(error != _LTRNative.LTRERROR.OK)
            {
                Log.Error("{0} Start", this);
                return error;
            }    
            
            base.Start();
            return _LTRNative.LTRERROR.OK;
        }

        public new void Stop()
        {
            base.Stop();

            ltr.Stop();
            ltr.Close();
            Log.Info("{0} Stop", this);
        }

        protected override Tuple<double[], int> ReadItem()
        {
            /* прием необработанных слов. в таймауте учитываем время выполнения самого преобразования */
            var size = ltr.Recv(rbuf, marks, (uint)rbuf.Length, 4000 + (uint)(1000*RECV_BLOCK_CH_SIZE/ltr.State.AdcFreq + 1));
            if (size == rbuf.Length)
            {
                ltr.ProcessData(rbuf, data, ref size, ltr25api.ProcFlags.Volt, ch_status);
                return Tuple.Create(data, size);
            }
            else
            {
                return Tuple.Create(data, 0);
            }
        }
        
        public override string ToString()
        {
            return $"Ltr25 [{slot}]";
        }
    }
}