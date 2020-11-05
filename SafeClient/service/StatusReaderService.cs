using System;
using System.Collections.Generic;
using System.Threading;
using api;
using model.camera;

namespace service
{
    public class StatusReaderService
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

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
            try
            {
                var serverApi = (IServerApi)obj;
                var statuses = serverApi.Statuses();
                var cameraSelected = new HashSet<CameraController>();
                foreach (var status in statuses)
                {
                    var dev = DI.Instance.DeviceService[status.id];
                    dev?.Update(status);

                    if (status.alarm > 0)
                    {
                        cameraSelected.Add(dev?.Camera);
                    }
                }
                DI.Instance.Invoke(new Action(() =>
                {
                    try
                    {
                        DI.Instance.CameraService.Selected(cameraSelected);
                    }
                    catch (Exception e)
                    {
                        Log.Error(e, "error camera select update");
                    }
                }));
            }
            catch (Exception e)
            {
                Log.Warn(e, e.Message);
            }
        }
    }
}