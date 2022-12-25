using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.IO;
using log4net.Config;

namespace BrainstormSessions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FileInfo configFile = new FileInfo("web.config");
            XmlConfigurator.Configure(configFile);

            Log.Logger = new LoggerConfiguration()
                .Enrich.WithProperty("Logging", "Program")
                .MinimumLevel.Information()
                .WriteTo.Log4Net()
                .WriteTo.File("Logs/structuredLog.log")
                .CreateLogger();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
