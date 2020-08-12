using ltrModulesNet;
using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace SafeServer.ltr
{
    public class Ltr42
    {
        private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

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

        public void Add(int index, IObservable<bool> i)
        {
            _indicators.Add(i.Select(enable => new BitsOp { Mask = 1 << index, Enable = enable }));
        }

        public void Start()
        {
            _ltr42api.LTR42_Open(ref _module, (uint)0x7F000001L, 11111, slot.ToCharArraySn(), slot.Num);

            /* Конфигурация меток */
            _module.Marks.SecondMark_Mode = 0; //  Секундная метка внутр. с трансляцией на выход
            _module.Marks.StartMark_Mode = 0; //  Метка СТАРТ внутренняя
            _module.AckEna = true; // подтверждения включены 
            _ltr42api.LTR42_Config(ref _module);

            _disposable = _indicators
                .Merge()
                .ObserveOn(NewThreadScheduler.Default)
                .Scan(0, (val, item) => item.Enable
                    ? val | item.Mask
                    : val & ~item.Mask)
                .DistinctUntilChanged()
                .Subscribe(val => Write(val));
        }

        public void Stop()
        {
            _disposable?.Dispose();
            Write(0);
            _ltr42api.LTR42_Close(ref _module);
        }

        private void Write(int data)
        {
            log.Info("LTR42_WritePort {0}", data);
            _ltr42api.LTR42_WritePort(ref _module, (ushort)data);
        }
    }
}
