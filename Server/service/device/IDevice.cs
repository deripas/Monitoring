using System;
using SafeServer.dto;

namespace SafeServer.service.device
{
    public abstract class IDevice
    {
        private bool enable;
        private bool removed;

        public long Id { get; set; }
        public int? CameraId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public long Version { get; set; }

        public bool Enable
        {
            get => enable;
            set
            {
                enable = value;
                OnEnableChange(IsEnable());
            }
        }
        
        public bool Removed
        {
            get => removed;
            set
            {
                removed = value;
                OnEnableChange(IsEnable());
            }
        }

        public abstract void Init();

        public abstract void Close();

        public abstract IObservable<DeviceStatus> Status();

        public abstract string RenderStatusValue(DeviceStatus status);
       
        public abstract void Update(Config cfg);

        public bool IsEnable()
        {
            return Enable && !Removed;
        }

        public virtual void OnEnableChange(bool enable)
        {

        }

        public override string ToString()
        {
            return $"[{Name}]";
        }
    }
}
