using api;
using api.dto;
using api.dto.client;
using api.impl;
using Properties;
using System;

namespace service
{
    public class DI
    {
        private static Guid EMPTY = Guid.Parse("00000000-0000-0000-0000-000000000000");

        public static DI Instance { get; } = new DI();
        
        public CameraService CameraService { get; set; }
        public DeviceService DeviceService { get; set; }
        public IServerApi ServerApi { get; set; }
        public AlarmSoundService AlarmSoundService { get; set; }
        public StatusReaderService StatusReaderService { get; set; }
        public ClientType Type { get; set; }
        public StandMode StandMode { get; set; }
        public Guid ClientId { get; set; }

        public bool IsViewMode
        {
            get
            {
                return DI.Instance.Type is ClientTypeView;
            }
        }

        public void Init()
        {
            if (EMPTY.Equals(Settings.Default.id))
            {
                Settings.Default.id = Guid.NewGuid();
            }
            ClientId = Settings.Default.id;
            Enum.TryParse(Settings.Default.StandMode, out StandMode mode);
            StandMode = mode;

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
            Settings.Default.Save();
            StatusReaderService.Dispose();
            CameraService.Dispose();
            DeviceService.Dispose();
            AlarmSoundService.Dispose();
        }
    }
}