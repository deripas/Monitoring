using System;
using System.Collections.Generic;

namespace SafeServer.dto
{
    public class DeviceStatus
    {
        public long id { get; set; }
        public bool enable { get; set; }
        public double value { get; set; }
        public long alarm { get; set; }


        public static DeviceStatus Value(long id, bool alert)
        {
            return Value(id, alert ? 1 : 0.0, alert);
        }

        public static DeviceStatus Value(long id, double val)
        {
            return Value(id, val, false);
        }

        public static DeviceStatus Value(long id, double val, bool alert)
        {
            return Value(id, val, alert ? DateTime.Now.Ticks : 0);
        }

        public static DeviceStatus Value(long id, double val, long alert)
        {
            return new DeviceStatus
            {
                id = id,
                value = val,
                alarm = alert
            };
        }

        public static DeviceStatus Reset(long id)
        {
            return new DeviceStatus
            {
                id = id,
                alarm = -1
            };
        }
               
        public static DeviceStatus Rollet(long id, bool up, bool dw)
        {
            return new DeviceStatus
            {
                id = id,
                value =  up 
                    ? dw ? 0 : 2
                    : dw ? 1 : 0
            };
        }
    }
}