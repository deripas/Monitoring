using System;
using System.Collections.Generic;

namespace SafeServer.dto
{
    public class DeviceStatus
    {
        public long id { get; set; }
        public long version { get; set; }
        public bool enable { get; set; }
        public double value { get; set; }
        public long alarm { get; set; }


        public static DeviceStatus Value(Device device, bool alert)
        {
            return Value(device, alert ? 1 : 0.0, alert);
        }

        public static DeviceStatus Value(Device device, double val)
        {
            return Value(device, val, false);
        }

        public static DeviceStatus Value(Device device, double val, bool alert)
        {
            return Value(device, val, alert ? DateTime.Now.Ticks : 0);
        }

        public static DeviceStatus Value(Device device, double val, long alert)
        {
            return new DeviceStatus
            {
                id = device.Id,
                version = device.Version,
                enable = device.Enable,
                value = val,
                alarm = alert
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
                value =  up 
                    ? dw ? 0 : 2
                    : dw ? 1 : 0
            };
        }
    }
}