using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                 .ConfigureLogging((ctx, logging) =>
                 {
                     var loggingSection = ctx.Configuration.GetSection("Logging");

                     logging.AddConfiguration(loggingSection);

                     logging.ClearProviders();
                     logging.AddConsole(cfg => cfg.TimestampFormat = "[dd/MM/yyyy HH:mm:ss]");
                 })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseLinuxTransport()
                        .UseStartup<Startup>();
                });
    }
}
