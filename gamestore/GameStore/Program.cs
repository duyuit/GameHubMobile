using GameStore.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace GameStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
           
            var host = BuildWebHost(args);
            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;

            //    try
            //    {
            //        // Set the databas
            //        var context = services.GetRequiredService<ApplicationDbContext>();
            //        AppInitializer initializer = new AppInitializer(context);
            //        initializer.Seed().Wait();
            //    }
            //    catch (Exception ex)
            //    {
            //    }
                host.Run();
            //}
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .UseStartup<Startup>()
                   .UseKestrel(options =>
                    {
                        options.Limits.MaxConcurrentUpgradedConnections = 100;
                    })
                   .Build();
    }
}
