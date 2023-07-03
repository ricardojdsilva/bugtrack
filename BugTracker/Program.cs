using BugTracker.Api.Models;
using BugTracker.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace BugTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //1. Get the IWebHost which will host this application.
            var host = CreateHostBuilder(args).Build();
           

            //2. Find the service layer within our scope.
            using (var scope = host.Services.CreateScope())
            {
                //3. Get the instance of bugDBContext in our services layer
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<BugTrackerDbContext>();

                //4. Call the DataGenerator to create sample data
                DataGenerator.Initialize(services);
            }

            //Continue to run the application
            host.Run();


            //CreateHostBuilder(args).Build().Run();
        }       

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
