using api;
using api.impl;

namespace service
{
    public class DI
    {
        public static DI Instance { get; } = new DI();
        
        public CameraService CameraService { get; set; }
        public IServerApi ServerApi { get; set; }
        
        
        public void Init()
        {
            ServerApi = new MockServerApi();
            CameraService = new CameraService(ServerApi.Cameras());
        }

        internal void Dispose()
        {
            CameraService.Dispose();
        }
    }
}