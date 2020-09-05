using System;
using SafeServer.dto;
using SafeServer.service.device;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SafeServer.service
{
    public class DeviceService
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        public IDevice this[long id] => map[id];
        public ICollection<IDevice> Devices => map.Values;

        private Dictionary<long, IDevice> map;


        public DeviceService()
        {
            map = new Dictionary<long, IDevice>();
        }

        private IDevice Create(Device dev)
        {
            if (dev.Type == null) return null;

            if(dev.Type.Equals("pressure"))
                return new DoubleMeasureDev(dev);
            if(dev.Type.Equals("temperature"))
                return new DoubleMeasureDev(dev);  
            if (dev.Type.Equals("smoke"))
                return new SmokeDevice(dev);
            if(dev.Type.Equals("water"))
                return new WaterDevice(dev);
            if (dev.Type.Equals("rollet"))
                return new RolletDevice(dev);
           if (dev.Type.Equals("hurble"))
                return new HurbleDevice(dev);

            Log.Warn("Unknown type [{0}] '{1}'", dev.Name, dev.Type);
            return null;
        }

        public void Init()
        {
            map.Clear();
            using var db = new DatabaseService();
            foreach (var dev in db.Device.ToList())
            {
                try
                {
                    db.Entry(dev).State = EntityState.Detached;
                    if (dev.Config == null) continue;

                    var d = Create(dev);
                    if(d == null) continue;
                    
                    map.Add(dev.Id, d);
                }
                catch (Exception ex)
                {
                    Log.Warn("Ignored [{0}]", dev.Name, ex);
                }
            }

            DI.Instance.MeasureWriter.Subscribe(map.Values);
            DI.Instance.AlertWriter.Subscribe(map.Values);
            DI.Instance.DeviceStatusService.Subscribe(map.Values);
        }

        public void Start()
        {
            foreach (var dev in map.Values)
                dev.Init();
        }

        internal void Dispose()
        {
            foreach (var dev in map.Values)
                dev.Close();
            map.Clear();
        }
    }
}
