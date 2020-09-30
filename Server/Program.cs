using System;
using System.Net;
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
        #region Nested classes to support running as service

        public class Service : ServiceBase
        {
            Task task;

            public Service()
            {
                ServiceName = "Server";
            }

            protected override void OnStart(string[] args)
            {
                task = Program.Start(args);
            }

            protected override void OnStop()
            {
                Program.Stop();
            }
        }
        #endregion

        public static void Main(string[] args)
        {
            if (!Environment.UserInteractive)
                // running as service
                using (var service = new Service())
                    ServiceBase.Run(service);
            else
            {
                // running as console app
                AppDomain.CurrentDomain.ProcessExit += (sender, eventArgs) => Stop();
                Start(args);
            }
        }

        private static Task Start(string[] args)
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
            return CreateHostBuilder(args).Build().RunAsync();
        }

        private static void Stop()
        {
            DI.Instance.Dispose();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder
                    .UseStartup<Startup>()
                    .ConfigureLogging(logging => { logging.SetMinimumLevel(LogLevel.Information); })
                    .UseKestrel((context, options) => { options.Listen(IPAddress.Any, 80); })
                    .UseNLog()
                    .UseIIS());
    }
}