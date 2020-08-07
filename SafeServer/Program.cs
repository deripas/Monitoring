using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Threading;
using System.Windows.Forms;

namespace SafeServer
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                CreateWebHostBuilder().Run();
            }).Start();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
          
        }

        private static IWebHost CreateWebHostBuilder() => WebHost
            .CreateDefaultBuilder()
            .UseStartup<Startup>()
            .Build();
    }
}
