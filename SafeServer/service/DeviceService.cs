using SafeServer.dto;
using SafeServer.service.device;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using Microsoft.EntityFrameworkCore.Internal;

namespace SafeServer.service
{
    public class DeviceService
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        public IDevice this[long id] => map[id];

        private Dictionary<long, IDevice> map;

        public DeviceService()
        {
            map = new Dictionary<long, IDevice>();
        }

        private List<Device> Devices()
        {
            using (var db = new DatabaseService())
            {
                return db.Device.ToList();
            }
        }

        private IDevice create(Device dev)
        {
            if (dev.Type == null) return null;

            // if(dev.Type.Equals("pressure"))
            //     return new PressureDev(dev);
            if (dev.Type.Equals("smoke"))
                return new SmokeDev(dev);
            if(dev.Type.Equals("water"))
            return new WaterDev(dev); 
            // if(dev.Type.Equals("temperature"))
            //     return new TemperatureDev(dev);  
            if (dev.Type.Equals("alarm"))
                return new AlarmDev(dev);

            return null;
        }

        public void Init()
        {
            foreach (var dev in Devices())
            {
                var d = create(dev);
                if (d == null) continue;

                map.Add(dev.Id, d);
            }

            map.Values
                .OfType<ISensorDevice>()
                .Where(d => d.Id() == 24)
                .Select(device => device.Status())
                .ToList()
                .Merge()
                .ObserveOn(NewThreadScheduler.Default);
            // .Subscribe(s =>
            // {
            //     Log.Info("{0} {1} ", s.id, s.alarm);
            // });

            SubscribeSiren();
        }

        private void SubscribeSiren()
        {
            var f = map.Values.OfType<IWithSirenDevice>();
            var t = map.Values.OfType<ISirenDevice>();

            var result = from w in f
                join s in t on w.SirenId() equals s.Id()
                select new {From = w, To = s};

            foreach (var item in result)
            {
                Log.Info("{0} => {1}", item.From, item.To);
                item.To.Subscribe(item.From.Siren());
            }
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
