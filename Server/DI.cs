using System;
using System.IO;
using System.Reactive.Linq;
using Microsoft.Extensions.Configuration;
using SafeServer.service;
using Server.service;

namespace SafeServer
{
    public class DI
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        public static DI Instance { get; } = new DI();

        public IConfigurationRoot Config;
        public DeviceService DeviceService;
        public LtrService LtrService;
        public MeasureWriter MeasureWriter;
        public AlertWriter AlertWriter;
        public DeviceStatusService DeviceStatusService;
        public CameraService CameraService;
        private IDisposable init;

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
            CameraService = new CameraService();
            LtrService = new LtrService();

            init = Observable.Defer(() =>
                {
                    Log.Info("Begin Init server");
                    CameraService.Init();
                    LtrService.Init();
                    DeviceService.Init();

                    var dev = DeviceService.Devices;
                    MeasureWriter.Subscribe(dev);
                    AlertWriter.Subscribe(dev);
                    DeviceStatusService.Subscribe(dev);
                    return Observable.Return(true);
                })
                .Do(_ => Log.Info("Complete Init server"), exception => Log.Error(exception, "Error Init server"))
                .RetryWhen(o => o.Delay(TimeSpan.FromSeconds(1)))
                .SelectMany(_ =>
                {
                    return Observable.Defer(() =>
                        {
                            Log.Info("Begin Start");
                            return LtrService.Start()
                                .SelectMany(s => DeviceService.Start());
                        })
                        .Do(_ => Log.Info("Complete Start"), exception => Log.Error(exception, "Error Start"))
                        .RetryWhen(o => o.Delay(TimeSpan.FromSeconds(1)));
                })
                .Subscribe();
        }

        internal void Dispose()
        {
            init?.Dispose();
            MeasureWriter?.Dispose();
            AlertWriter?.Dispose();
            DeviceStatusService?.Dispose();
            DeviceService?.Dispose();
            CameraService?.Dispose();
            LtrService?.Dispose();

            AlertWriter = null;
            MeasureWriter = null;
            DeviceStatusService = null;
            DeviceService = null;
            CameraService = null;
            LtrService = null;
        }
    }
}
