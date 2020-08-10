using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Config;
using NLog.Targets;
using NLog.Targets.Wrappers;
using NLog.Web;
using NLog.Windows.Forms;
using Npgsql.Logging;
using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SafeServer
{
    public partial class MainForm : Form
    {
        private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();


        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            InitLogger();
            InitServer();
        }

        private void InitLogger()
        {
            RichTextBoxTarget console = new RichTextBoxTarget();
            console.Layout = "${date:format=HH\\:MM\\:ss} [${threadid}] ${level:uppercase=true} ${logger} - ${message}${exception:format=ToString}";
            console.ControlName = richTextBox1.Name;
            console.FormName = this.Name;
            console.UseDefaultRowColoringRules = true;

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
            log.Info("Init logger");
        }

        private void InitServer()
        {
            new Thread(() =>
            {
                log.Info("Start init server...");
                Thread.CurrentThread.IsBackground = true;
                CreateWebHostBuilder().Run();
            }).Start();
        }

        private static IWebHost CreateWebHostBuilder() => WebHost
            .CreateDefaultBuilder()
            .UseStartup<Startup>()
            .ConfigureLogging(logging =>
            {
               logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Information);
            })
            .UseNLog()
            .Build();
    }
}
