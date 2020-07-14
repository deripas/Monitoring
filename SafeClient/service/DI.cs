using System.Configuration;
using System.Runtime.InteropServices;
using api;
using api.impl;

namespace service
{
    public class DI
    {
        public static DI Instance { get; } = new DI();
        
        public NvrService NvrService { get; set; }
        public CameraService CameraService { get; set; }
        public IServerApi ServerApi { get; set; }
        
        
        public void Init()
        {
            ServerApi = new MockServerApi();
            NvrService = new NvrService();
            CameraService = new CameraService(NvrService, ServerApi.Cameras());

        }

        internal void Dispose()
        {
            NvrService.Dispose();
        }
    }
}