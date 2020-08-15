using SafeServer.service;

namespace SafeServer
{
    public class DI
    {
        public static DI Instance { get; } = new DI();

        public DeviceService DeviceService;
        public LtrService LtrService;
        public MeasureWriter MeasureWriter;

        public void Init()
        {
            MeasureWriter = new MeasureWriter();
            DeviceService = new DeviceService();
            LtrService = new LtrService();

            DeviceService.Init();
            LtrService.Start();
            DeviceService.Start();
        }

        internal void Dispose()
        {
            MeasureWriter?.Dispose();
            DeviceService?.Dispose();
            LtrService?.Dispose();

            MeasureWriter = null;
            DeviceService = null;
            LtrService = null;
        }
    }
}
