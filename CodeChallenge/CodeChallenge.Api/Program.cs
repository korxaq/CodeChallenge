using System;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CodeChallenge.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    host.Run();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex.Message);
                    logger.LogError(ex.StackTrace);
                }
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(s =>
                {
                    s.AddAutofac();
                })
                .ConfigureLogging((hostingContext, logging) =>
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging")
                    ))
                .UseStartup<Startup>()
                .Build();
    }
}
