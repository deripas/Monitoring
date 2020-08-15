using SafeServer.dto;
using SafeServer.ltr;

namespace SafeServer.service.device
{
    public abstract class LtrDevice : IDevice
    {
        protected Device device;
        
        protected LtrDevice(Device device)
        {
            this.device = device;
        }

        public long Id()
        {
            return device.Id;
        }

        public abstract void Init();

        public abstract void Reset();
        public abstract void Close();

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
        
                
        public override string ToString()
        {
            return $"[{device.Name}]";
        }
    }
}