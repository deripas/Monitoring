using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using SafeServer.dto;
using SafeServer.service.device;

namespace SafeServer.service
{
    public class DeviceStatusService
    {
        private BehaviorSubject<Dictionary<long, DeviceStatus>> statuses;
        private IDisposable _disposable;

        public DeviceStatusService()
        {
            statuses = new BehaviorSubject<Dictionary<long, DeviceStatus>>(new Dictionary<long, DeviceStatus>());
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }

        public List<DeviceStatus> GetStatuses()
        {
            return statuses.Value.Values.ToList();
        }

        public void Subscribe(ICollection<IDevice> devices)
        {
            _disposable = devices
                .Select(device => device.Status())
                .Merge()
                .Where(status => !status.reset)
                .Scan(new Dictionary<long, DeviceStatus>(),
                    (dictionary, sensorStatus) => new Dictionary<long, DeviceStatus>(dictionary) {[sensorStatus.id] = sensorStatus})
                .Subscribe(statuses);
        }
    }
}