using System;
using System.Reactive.Subjects;
using SafeServer.dto;
using SafeServer.dto.config;
using SafeServer.ltr;

namespace SafeServer.service.device
{
    public abstract class LtrDevice : IDevice
    {
        protected readonly Device device;
        protected readonly Config config;
        
        protected LtrDevice(Device device)
        {
            this.device = device;
            config = device.Config;
        }

        public long Id()
        {
            return device.Id;
        }

        public abstract void Init();
        public abstract void Close();
        public abstract IObservable<DeviceStatus> Status();

        protected static void Add42(Channel ch, IObservable<bool> @in)
        {
            Ltr42(ch.GetSlot())[ch.index] = @in;
        }

        protected static IObservable<Tuple<bool[], int>> GetBool41(Channel ch)
        {
            return Ltr41(ch.GetSlot())[ch.index];
        }
        
        protected static IObservable<Tuple<double[], int>> GetDouble27(Channel ch)
        {
            return Ltr27(ch.GetSlot())[ch.index];
        }
        
        protected static Ltr41 Ltr41(Slot slot)
        {
            return DI.Instance.LtrService.GetLtr<Ltr41>(slot);
        }
        
        protected static Ltr42 Ltr42(Slot slot)
        {
            return DI.Instance.LtrService.GetLtr<Ltr42>(slot);
        }

        protected static Ltr27 Ltr27(Slot slot)
        {
            return DI.Instance.LtrService.GetLtr<Ltr27>(slot);
        }
        
        protected static Ltr25 Ltr25(Slot slot)
        {
            return DI.Instance.LtrService.GetLtr<Ltr25>(slot);
        }

        public override string ToString()
        {
            return $"[{device.Name}]";
        }
    }
}