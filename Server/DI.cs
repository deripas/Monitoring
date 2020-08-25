using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using SafeServer.service;

namespace SafeServer
{
    public class DI
    {
        public static DI Instance { get; } = new DI();

        public IConfigurationRoot Config;
        public DeviceService DeviceService;
        public LtrService LtrService;
        public MeasureWriter MeasureWriter;
        public AlertWriter AlertWriter;
        public DeviceStatusService DeviceStatusService;

        public void Init()
        {
            Config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();
            
            MeasureWriter = new MeasureWriter();
            AlertWriter = new AlertWriter();
            DeviceStatusService = new DeviceStatusService();
            DeviceService = new DeviceService();
            LtrService = new LtrService();

            DeviceService.Init();
            LtrService.Start();
            DeviceService.Start();
        }

        internal void Dispose()
        {
            MeasureWriter?.Dispose();
            AlertWriter?.Dispose();
            DeviceStatusService?.Dispose();
            DeviceService?.Dispose();
            LtrService?.Dispose();

            AlertWriter = null;
            MeasureWriter = null;
            DeviceStatusService = null;
            DeviceService = null;
            LtrService = null;
        }
    }
}
