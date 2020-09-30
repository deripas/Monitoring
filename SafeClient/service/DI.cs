using api;
using api.dto;
using api.dto.client;
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
        public StatusReaderService StatusReaderService { get; set; }
        public ClientType Type { get; set; }
        
        
        public void Init()
        {
            ServerApi = new RestServerApi();
            CameraService = new CameraService(ServerApi);
            DeviceService = new DeviceService(ServerApi);
            StatusReaderService = new StatusReaderService(ServerApi);
            AlarmSoundService = new AlarmSoundService();

            ClientTypeFactory typeFactory = new ClientTypeFactory();
            Type = typeFactory.Create();
        }

        internal void Dispose()
        {
            StatusReaderService.Dispose();
            CameraService.Dispose();
            DeviceService.Dispose();
            AlarmSoundService.Dispose();
        }
    }
}