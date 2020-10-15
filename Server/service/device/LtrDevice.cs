using System;
using SafeServer.dto;
using SafeServer.dto.config;
using SafeServer.ltr;

namespace SafeServer.service.device
{
    public abstract class LtrDevice : IDevice
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        protected readonly Config Config;
        
        protected LtrDevice(Device device)
        {
            Id = device.Id;
            Name = device.Name;
            Type = device.Type;
            CameraId = device.Camera;
            Version = device.Version;
            Enable = device.Enable;
            Removed = device.Removed;
            Config = device.Config;
        }

        public override void Update(Config cfg)
        {
            if (cfg.simple == null) return;
            Removed = !cfg.simple.enable;
            Log.Info("{}({}) enable status {}", Name, Id, cfg.simple.enable);
        }

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
        
        protected static IObservable<Tuple<double[], int>> GetDouble25(Channel ch)
        {
            return Ltr25(ch.GetSlot())[ch.index];
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
    }
}