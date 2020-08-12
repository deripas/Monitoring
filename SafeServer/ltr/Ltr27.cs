using ltrModulesNet;
using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace SafeServer.ltr
{
    public class Ltr27 : LtrRead<Tuple<double[], int>>
    {
        private Slot slot;
        private _ltr27api.TLTR27 _module;
        private readonly uint[] _data = new uint[1024];
        private readonly double[] _value = new double[1024];
        private readonly int _channels = 16;

        public Ltr27(Slot slot)
        {
            this.slot = slot;
            _ltr27api.LTR27_Init(ref _module);
        }

        public void Add(int index, IObserver<Tuple<double[], int>> sensor)
        {
            Add(new Subject<Tuple<double[], int>>())
                .ObserveOn(NewThreadScheduler.Default)
                .Scan(Tuple.Create(new double[1024], 0), (accum, cur) =>
                {
                    var (inArray, size) = cur;
                    var (outArray, _) = accum;

                    for (int i = 0, k = index; k < size; i++, k += _channels)
                        outArray[i] = inArray[k];

                    return Tuple.Create(outArray, size / _channels);
                })
                .Subscribe(sensor);
        }

        public new void Start()
        {
            _ltr27api.LTR27_Open(ref _module, (uint)0x7F000001L, 11111, slot.ToCharArraySn(), (ushort)slot.Num);
            _ltr27api.LTR27_GetConfig(ref _module);
            _ltr27api.LTR27_GetDescription(ref _module, _ltr27api.LTR27_MODULE_DESCRIPTION);

            for (var i = 0; i < _ltr27api.LTR27_MEZZANINE_NUMBER; i++)
            {
                var name = GetStr(_module.Mezzanine[i].Name);
                if (name.Equals("EMPTY")) continue;

                _ltr27api.LTR27_GetDescription(ref _module, (ushort)(_ltr27api.LTR27_MEZZANINE1_DESCRIPTION << i));
                _module.Mezzanine[i].CalibrCoeff = _module.ModuleInfo.Mezzanine[i].Calibration;
            }

            _module.FrequencyDivisor = 0;
            _ltr27api.LTR27_SetConfig(ref _module);
            _ltr27api.LTR27_ADCStart(ref _module);

            base.Start();
        }

        public new void Stop()
        {
            base.Stop();

            _ltr27api.LTR27_ADCStop(ref _module);
            _ltr27api.LTR27_Close(ref _module);
        }

        private static string GetStr(char[] ch)
        {
            return new string(ch).Replace('\0', ' ').Trim();
        }

        protected override Tuple<double[], int> ReadItem()
        {
            var size = (uint)_data.Length;
            _ltr27api.LTR27_Recv(ref _module, _data, null, size, 1000);
            var ok = _ltr27api.LTR27_ProcessData(ref _module, _data, _value, ref size, true, true) == _LTRNative.LTRERROR.OK;
            return Tuple.Create(_value, ok ? (int)size : 0);
        }
    }
}
