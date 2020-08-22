using System;
using System.Threading;
using api;

namespace service
{
    public class StatusReaderService
    {
        private Timer _timer;
        
        public StatusReaderService(IServerApi serverApi)
        {
            _timer = new Timer(callback, serverApi, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
        }

        internal void Dispose()
        {
            _timer.Dispose();
        }

        private void callback(object obj)
        {
            var serverApi = (IServerApi) obj;
            var statuses = serverApi.Statuses();
            foreach (var status in statuses)
            {
                DI.Instance.DeviceService[status.id]?.Update(status);
            }
        }
    }
}