using ltrModulesNet;
using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace SafeServer.ltr
{
    public class Ltr41 : LtrRead<Tuple<ushort[], int>>
    {
        private Slot slot;
        private _ltr41api.TLTR41 _module;
        private readonly uint[] _data = new uint[1024];
        private readonly ushort[] _rez = new ushort[1024];

        public Ltr41(Slot slot)
        {
            this.slot = slot;
            _ltr41api.LTR41_Init(ref _module);
        }

        public void Add(int index, IObserver<Tuple<bool[], int>> sensor)
        {
            Add(new Subject<Tuple<ushort[], int>>())
                .ObserveOn(NewThreadScheduler.Default)
                .Scan(Tuple.Create(new bool[1024], 0), (accum, cur) =>
                {
                    var (inArray, size) = cur;
                    var (outArray, _) = accum;

                    for (var i = 0; i < size; i++)
                        outArray[i] = ((inArray[i] >> index) & 1) == 1;

                    return Tuple.Create(outArray, size);
                })
                .Subscribe(sensor);
        }

        public new void Start()
        {
            _ltr41api.LTR41_Open(ref _module, (uint)0x7F000001L, 11111, slot.ToCharArraySn(), slot.Num);

            /* Конфигурация меток */
            _module.Marks.SecondMark_Mode = 0; //  Секундная метка внутр. с трансляцией на выход
            _module.Marks.StartMark_Mode = 0; //  Метка СТАРТ внутренняя
            //module.StreamReadRate = 10000;
            _ltr41api.LTR41_Config(ref _module);
            _ltr41api.LTR41_StartStreamRead(ref _module);

            base.Start();
        }

        public new void Stop()
        {
            base.Stop();

            _ltr41api.LTR41_StopStreamRead(ref _module);
            _ltr41api.LTR41_Close(ref _module);
        }

        protected override Tuple<ushort[], int> ReadItem()
        {
            var size = _data.Length;
            _ltr41api.LTR41_Recv(ref _module, _data, null, (uint)_data.Length, 1000);
            var ok = _ltr41api.LTR41_ProcessData(ref _module, _data, _rez, ref size) == _LTRNative.LTRERROR.OK;
            return Tuple.Create(_rez, ok ? size : 0);
        }
    }
}
