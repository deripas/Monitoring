using ltrModulesNet;
using System;
using System.Reactive.Linq;

namespace SafeServer.ltr
{
    public class Ltr27 : LtrRead<Tuple<double[], int>>, ILtr
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        public IObservable<Tuple<double[], int>> this[int index]
        {
            get
            {
                var seed = Tuple.Create(new double[_value.Length], 0);
                return Data.Scan(seed, (accum, cur) =>
                {
                    var (inArray, size) = cur;
                    var (outArray, _) = accum;

                    for (int i = 0, k = index; k < size; i++, k += _channels)
                        outArray[i] = inArray[k];

                    return Tuple.Create(outArray, size / _channels);
                });
            }
        }

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

        public new _LTRNative.LTRERROR Start()
        {
            Log.Info("{0} Start", this);
            var error = _ltr27api.LTR27_Open(ref _module, (uint)0x7F000001L, 11111, slot.ToCharArraySn(), (ushort)slot.num);
            if(error != _LTRNative.LTRERROR.OK)
            {
                Log.Error("{0} LTR27_Open", this);
                return error;
            }   
            
            error = _ltr27api.LTR27_GetConfig(ref _module);
            if(error != _LTRNative.LTRERROR.OK)
            {
                Log.Error("{0} LTR27_GetConfig", this);
                return error;
            } 
            
            error = _ltr27api.LTR27_GetDescription(ref _module, _ltr27api.LTR27_MODULE_DESCRIPTION);
            if(error != _LTRNative.LTRERROR.OK)
            {
                Log.Error("{0} LTR27_GetDescription", this);
                return error;
            } 

            for (var i = 0; i < _ltr27api.LTR27_MEZZANINE_NUMBER; i++)
            {
                var name = new string(_module.Mezzanine[i].Name).TrimEnd('\0');
                if (name.Equals("EMPTY")) continue;

                _ltr27api.LTR27_GetDescription(ref _module, (ushort)(_ltr27api.LTR27_MEZZANINE1_DESCRIPTION << i));
                _module.Mezzanine[i].CalibrCoeff = _module.ModuleInfo.Mezzanine[i].Calibration;
            }

            _module.FrequencyDivisor = 0;
            error = _ltr27api.LTR27_SetConfig(ref _module);
            if(error != _LTRNative.LTRERROR.OK)
            {
                Log.Error("{0} LTR27_SetConfig", this);
                return error;
            } 
            
            error = _ltr27api.LTR27_ADCStart(ref _module);
            if(error != _LTRNative.LTRERROR.OK)
            {
                Log.Error("{0} LTR27_ADCStart", this);
                return error;
            } 

            base.Start();
            return _LTRNative.LTRERROR.OK;
        }

        public new void Stop()
        {
            base.Stop();

            _ltr27api.LTR27_ADCStop(ref _module);
            _ltr27api.LTR27_Close(ref _module);
            Log.Info("{0} Stop", this);
        }

        protected override Tuple<double[], int> ReadItem()
        {
            var size = (uint)_data.Length;
            _ltr27api.LTR27_Recv(ref _module, _data, null, size, 1000);
            var ok = _ltr27api.LTR27_ProcessData(ref _module, _data, _value, ref size, true, true) == _LTRNative.LTRERROR.OK;
            return Tuple.Create(_value, ok ? (int)size : 0);
        }
        
        public override string ToString()
        {
            return $"Ltr27 [{slot}]";
        }
    }
}
