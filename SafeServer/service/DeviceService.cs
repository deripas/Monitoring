using System;
using SafeServer.dto;
using SafeServer.service.device;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace SafeServer.service
{
    public class DeviceService
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        public IDevice this[long id] => map[id];

        private Dictionary<long, IDevice> map;
        private BehaviorSubject<Dictionary<long, SensorStatus>> statuses;
        private IDisposable _disposable;

        public DeviceService()
        {
            map = new Dictionary<long, IDevice>();
            statuses = new BehaviorSubject<Dictionary<long, SensorStatus>>(new Dictionary<long, SensorStatus>());
        }

        private List<Device> Devices()
        {
            using (var db = new DatabaseService())
            {
                return db.Device.ToList();
            }
        }

        private IDevice Create(Device dev)
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

            Log.Warn("Unknown type [{0}] '{1}'", dev.Name, dev.Type);
            return null;
        }

        public void Init()
        {
            foreach (var dev in Devices())
            {
                try
                {
                    if (dev.Config == null) continue;

                    var d = Create(dev);
                    if(d == null) continue;
                    
                    map.Add(dev.Id, d);
                }
                catch (Exception ex)
                {
                    Log.Warn("Ignored [{0}]", dev.Name);
                }
            }

            SubscribeSiren();
            SubscribeStatus();
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

        private void SubscribeStatus()
        {
            var status = map.Values
                .OfType<ISensorDevice>()
                .Select(device => device.Status())
                .ToList()
                .Merge();
            
            DI.Instance.MeasureWriter.Subscribe(status);

            _disposable = status
                .Scan(new Dictionary<long, SensorStatus>(), (dictionary, sensorStatus) =>
                {
                    if(dictionary.ContainsKey(sensorStatus.id))
                        dictionary[sensorStatus.id] = sensorStatus;
                    else
                        dictionary.Add(sensorStatus.id, sensorStatus);
                    return new Dictionary<long, SensorStatus>(dictionary);
                })
                .Sample(TimeSpan.FromMilliseconds(500))
                .Subscribe(statuses);
        }

        public void Start()
        {
            foreach (var dev in map.Values)
                dev.Init();
        }

        internal void Dispose()
        {
            _disposable?.Dispose();
            foreach (var dev in map.Values)
                dev.Close();
            map.Clear();
        }

        public List<SensorStatus> GetAllStatus()
        {
            return statuses.Value.Values.ToList();
        }

        public void UpdateConfig(long id, Config config)
        {
            using (var db = new DatabaseService())
            {
                var dev = db.Device.Find(id);
                dev.Version += 1;
                dev.Config = config;
                db.SaveChanges();
            }
        }
    }
}
