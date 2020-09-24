using ltrModulesNet;
using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace SafeServer.ltr
{
    public class Ltr42 : ILtr
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        public IObservable<bool> this[int index]
        {
            set
            {
                _indicators.Add(value.Select(enable => new BitsOp { Mask = 1 << index, Enable = enable }));
            }
        }

        private Slot slot;
        private _ltr42api.TLTR42 _module;
        private IDisposable _disposable;
        private readonly List<IObservable<BitsOp>> _indicators;

        public Ltr42(Slot slot)
        {
            this.slot = slot;
            _ltr42api.LTR42_Init(ref _module);
            _indicators = new List<IObservable<BitsOp>>();
        }

        public _LTRNative.LTRERROR Start()
        {
            Log.Info("{0} Start", this);
            var error = _ltr42api.LTR42_Open(ref _module, (uint)0x7F000001L, 11111, slot.ToCharArraySn(), slot.num);
            if(error != _LTRNative.LTRERROR.OK)
            {
                Log.Error("{0} LTR42_Open", this);
                return error;
            }    
            /* Конфигурация меток */
            _module.Marks.SecondMark_Mode = 0; //  Секундная метка внутр. с трансляцией на выход
            _module.Marks.StartMark_Mode = 0; //  Метка СТАРТ внутренняя
            _module.AckEna = true; // подтверждения включены 
            error = _ltr42api.LTR42_Config(ref _module);
            if(error != _LTRNative.LTRERROR.OK)
            {
                Log.Error("{0} LTR42_Config", this);
                return error;
            }   
            
            _disposable = _indicators
                .Merge()
                .ObserveOn(NewThreadScheduler.Default)
                .Scan(0, (val, item) => item.Enable
                    ? val | item.Mask
                    : val & ~item.Mask)
                .DistinctUntilChanged()
                .Subscribe(Write);
            return _LTRNative.LTRERROR.OK;
        }

        public void Stop()
        {
            _disposable?.Dispose();
            Write(0);
            _ltr42api.LTR42_Close(ref _module);
            Log.Info("{0} Stop", this);
        }

        private void Write(int data)
        {
            Log.Trace("{0} LTR42_WritePort {1}", slot, data);
            _ltr42api.LTR42_WritePort(ref _module, (ushort)data);
        }
        
        public override string ToString()
        {
            return $"Ltr42 [{slot}]";
        }
    }
}
