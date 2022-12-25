using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.IO;
using System.Net;
using log4net.Config;
using Serilog.Events;
using Serilog.Sinks.Email;

namespace BrainstormSessions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var senderEmail = Environment.GetEnvironmentVariable("SENDER");
            var password = Environment.GetEnvironmentVariable("PASSWORD");
            var receiverEmail = Environment.GetEnvironmentVariable("RECEIVER");

            Log.Logger = new LoggerConfiguration()
                .Enrich.WithProperty("Logging", "Program")
                .MinimumLevel.Information()
                .WriteTo.File("Logs/structuredLog.json")
                .WriteTo.Email(restrictedToMinimumLevel: LogEventLevel.Information,
                    period: TimeSpan.FromSeconds(5), 
                    batchPostingLimit:2,
                    connectionInfo: new EmailConnectionInfo
                    {
                        EmailSubject = "APP Logs",
                        NetworkCredentials = new NetworkCredential(senderEmail, password),
                        FromEmail = senderEmail,
                        ToEmail = receiverEmail,
                        MailServer = "smtp.gmail.com",
                        EnableSsl = true,
                        Port = 465
                    })
                .CreateLogger();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseSerilog();
    }
}
