using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
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
            InitLogger();
            CreateHostBuilder(args).Build().Run();
        }

        public static void InitLogger()
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
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder
                    .UseStartup<Startup>()
                    .UseNLog()
                    .ConfigureLogging(logging => { logging.SetMinimumLevel(LogLevel.Information); })
                )
                .ConfigureWebHost(config =>
                {
                    config.UseUrls("http://*:80");
                })
                .UseWindowsService();
    }
}