using ltrModulesNet;
using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace SafeServer.ltr
{
    public class Ltr41 : LtrRead<Tuple<ushort[], int>>, ILtr
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        public IObservable<Tuple<bool[], int>> this[int index]
        {
            get
            {
                var seed = Tuple.Create(new bool[_data.Length], 0);
                return Data.Scan(seed, (accum, cur) =>
                {
                    var (inArray, size) = cur;
                    var (outArray, _) = accum;

                    for (var i = 0; i < size; i++)
                        outArray[i] = ((inArray[i] >> index) & 1) == 1;

                    return Tuple.Create(outArray, size);
                });
            }
        }

        private Slot slot;
        private _ltr41api.TLTR41 _module;
        private readonly uint[] _data = new uint[1024];
        private readonly ushort[] _rez = new ushort[1024];

        public Ltr41(Slot slot)
        {
            this.slot = slot;
            _ltr41api.LTR41_Init(ref _module);
        }

        public new _LTRNative.LTRERROR Start()
        {
            Log.Info("{0} Start", this);
            var error = _ltr41api.LTR41_Open(ref _module, (uint)0x7F000001L, 11111, slot.ToCharArraySn(), slot.num);
            if (error != _LTRNative.LTRERROR.OK)
            {
                Log.Error("{0} LTR41_Open", this);
                return error;
            }
            /* Конфигурация меток */
            _module.Marks.SecondMark_Mode = 0; //  Секундная метка внутр. с трансляцией на выход
            _module.Marks.StartMark_Mode = 0; //  Метка СТАРТ внутренняя
            //module.StreamReadRate = 10000;
            error = _ltr41api.LTR41_Config(ref _module);
            if (error != _LTRNative.LTRERROR.OK)
            {
                Log.Error("{0} LTR41_Config", this);
                return error;
            }
            
            error = _ltr41api.LTR41_StartStreamRead(ref _module);
            if (error != _LTRNative.LTRERROR.OK)
            {
                Log.Error("{0} LTR41_StartStreamRead", this);
                return error;
            }
            base.Start();
            return _LTRNative.LTRERROR.OK;
        }

        public new void Stop()
        {
            base.Stop();

            _ltr41api.LTR41_StopStreamRead(ref _module);
            _ltr41api.LTR41_Close(ref _module);
            Log.Info("{0} Stop", this);
        }

        protected override Tuple<ushort[], int> ReadItem()
        {
            var size = _data.Length;
            _ltr41api.LTR41_Recv(ref _module, _data, null, (uint)_data.Length, 1000);
            var ok = _ltr41api.LTR41_ProcessData(ref _module, _data, _rez, ref size) == _LTRNative.LTRERROR.OK;
            return Tuple.Create(_rez, ok ? size : 0);
        }
        
        public override string ToString()
        {
            return $"Ltr41 [{slot}]";
        }
    }
}
