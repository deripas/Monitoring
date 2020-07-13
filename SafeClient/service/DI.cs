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
        public IServerApi ServerApi { get; set; }
        
        
        public void Init()
        {
            ServerApi = new MockServerApi();
            NvrService = new NvrService();
            //CameraService = new CameraService(NvrService, ServerApi.Cameras());

            SetDllDirectory(ConfigurationManager.AppSettings["cms.dir"]);
            NvrService.Init();
        }

        internal void Dispose()
        {
            NvrService.Dispose();
        }
        
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool SetDllDirectory(string lpPathName);
    }
}