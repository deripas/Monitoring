using api;
using api.impl;

namespace service
{
    public class DI
    {
        public static DI Instance { get; } = new DI();
        
        public CameraService CameraService { get; set; }
        public DeviceService DeviceService { get; set; }
        public IServerApi ServerApi { get; set; }
        public AlarmSoundService AlarmSoundService { get; set; }
        
        
        public void Init()
        {
            ServerApi = new MockServerApi();
            CameraService = new CameraService(ServerApi);
            DeviceService = new DeviceService(ServerApi);
            AlarmSoundService = new AlarmSoundService();
        }

        internal void Dispose()
        {
            CameraService.Dispose();
            DeviceService.Dispose();
            AlarmSoundService.Dispose();
        }
    }
}