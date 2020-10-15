using System;
using SafeServer.dto;
using SafeServer.service.device;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
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
            if (dev.Type.Equals("vibration"))
                return new VibrationDevice(dev);
            if (dev.Type.Equals("vibration2"))
                return new VibrationDevice2(dev);
            
            Log.Warn("Unknown type [{0}] '{1}'", dev.Name, dev.Type);
            return null;
        }

        public void Init()
        {
            var sql = @"
WITH dev AS (
    select d.id, name, enable, removed, camera, type, description, version, stand_id, siren,
           d.config || json_object_agg(m.field, json_build_object('sn', m.sn, 'num', m.num, 'index', m.ch - 1))::jsonb as config
    from ltr_device m,
         device d
    where m.device = d.id
    group by d.id
)
select d.id, name, enable, removed, camera, type, description, version, stand_id, siren, 
       d.config || json_build_object('siren', json_build_object('sn', m.sn, 'num', m.num, 'index', m.ch - 1))::jsonb as config
from dev d,
     ltr_device m
where d.siren = m.device
order by d.id;
";
                
            map.Clear();
            using var db = new DatabaseService();
            var list = db.Device.FromSqlRaw(sql).ToList();
            foreach (var dev in list)
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
        }

        public IObservable<bool> Start()
        {
            return Observable.Defer(() =>
                {
                    Log.Info("Start Device");
                    foreach (var dev in map.Values)
                        dev.Init();
                    return Observable.Return(true);
                })
                .Do(_ => Log.Info("Complete Start Device"), exception => Log.Error(exception, "Error Start Device"))
                .RetryWhen(o => o.Delay(TimeSpan.FromSeconds(1)));
        }

        internal void Dispose()
        {
            foreach (var dev in map.Values)
                dev.Close();
            map.Clear();
        }
    }
}
