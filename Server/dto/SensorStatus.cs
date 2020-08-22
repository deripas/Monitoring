using System;
using System.Collections.Generic;

namespace SafeServer.dto
{
    public class SensorStatus
    {
        public long id { get; set; }
        public long version { get; set; }
        public bool enable { get; set; }
        public bool reset { get; set; }
        public double value { get; set; }
        public bool alarm { get; set; }
        
        public bool up { get; set; }
        public bool dw { get; set; }

        public static SensorStatus Value(Device device, bool alert)
        {
            return Value(device, alert ? 1 : 0.0, alert);
        }

        public static SensorStatus Value(Device device, double val, bool alert)
        {
            return new SensorStatus
            {
                id = device.Id,
                version = device.Version,
                enable = device.Enable,
                value = val,
                alarm = alert
            };
        }
        
        public static SensorStatus Reset(Device device)
        {
            return new SensorStatus
            {
                id = device.Id,
                version = device.Version,
                enable = device.Enable,
                reset = true,
                alarm = false,
                value = double.NaN
            };
        }
        
        public static SensorStatus Empty(Device device)
        {
            return new SensorStatus
            {
                id = device.Id,
                version = device.Version,
                enable = device.Enable,
                reset = false,
                alarm = false,
                value = Double.NaN
            };
        }
        
        public static SensorStatus Rollet(Device device, bool up, bool dw)
        {
            return new SensorStatus
            {
                id = device.Id,
                version = device.Version,
                enable = device.Enable,
                reset = false,
                alarm = false,
                value = Double.NaN,
                up = up,
                dw = dw
            };
        }
    }
}