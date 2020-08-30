using System;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Config;
using NLog.Targets;
using NLog.Targets.Wrappers;
using NLog.Web;
using SafeServer;

namespace Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ColoredConsoleTarget console = new ColoredConsoleTarget();
            console.Layout = "${date:format=HH\\:MM\\:ss} [${threadid}] ${level:uppercase=true} ${logger} - ${message}${exception:format=ToString}";

            FileTarget file = new FileTarget();
            file.Layout = "${date:format=HH\\:MM\\:ss} [${threadid}] ${level:uppercase=true} ${logger} - ${message}${exception:format=ToString}";
            file.FileName = "${basedir}/logs/${shortdate}.log";
            file.KeepFileOpen = true;
            file.Encoding = Encoding.UTF8;
            file.MaxArchiveDays = 30;
            file.ArchiveAboveSize = 10240000;
            file.ArchiveEvery = FileArchivePeriod.Day;

            SplitGroupTarget target = new SplitGroupTarget();
            target.Targets.Add(console);
            target.Targets.Add(file);

            SimpleConfigurator.ConfigureForTargetLogging(target, NLog.LogLevel.Debug);

            DI.Instance.Init();
            AppDomain.CurrentDomain.ProcessExit += (sender, eventArgs) => DI.Instance.Dispose();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder
                    .UseStartup<Startup>()
                    .ConfigureLogging(logging => { logging.SetMinimumLevel(LogLevel.Information); })
                    .UseNLog()
                    .UseKestrel((context, options) => { options.Listen(IPAddress.Any, 5000); })
                    );
    }
}