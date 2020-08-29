using System;
using System.Collections.Generic;

namespace SafeServer.dto
{
    public class DeviceStatus
    {
        public long id { get; set; }
        public long version { get; set; }
        public bool enable { get; set; }
        public double? value { get; set; }
        public long alarm { get; set; }
        
        public bool up { get; set; }
        public bool dw { get; set; }

        public DeviceStatus Add(DeviceStatus s)
        {
            s.alarm = s.alarm >= 0 ? Math.Max(s.alarm, this.alarm) : 0;
            s.value = s.HasValue() ? s.value : this.value;
            return s;
        }

        public static DeviceStatus Value(Device device, bool alert)
        {
            return Value(device, alert ? 1 : 0.0, alert);
        }

        public static DeviceStatus Value(Device device, double val, bool alert)
        {
            return new DeviceStatus
            {
                id = device.Id,
                version = device.Version,
                enable = device.Enable,
                value = val,
                alarm = alert ? DateTime.Now.Ticks : 0
            };
        }
        
        public static DeviceStatus Reset(Device device)
        {
            return new DeviceStatus
            {
                id = device.Id,
                version = device.Version,
                enable = device.Enable,
                alarm = -1
            };
        }
        
       
        public static DeviceStatus Rollet(Device device, bool up, bool dw)
        {
            return new DeviceStatus
            {
                id = device.Id,
                version = device.Version,
                enable = device.Enable,
                up = up,
                dw = dw
            };
        }

        public bool HasValue()
        {
            return enable && value != null && !double.IsNaN(value.Value);
        }

        public double GetValue()
        {
            if (HasValue()) return value.Value;
            throw new Exception("???");
        }
    }
}