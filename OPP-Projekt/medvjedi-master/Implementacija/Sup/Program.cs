using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sup.Models;

namespace Sup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
	
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<DatabaseContext>();
                    InitializeDb(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();
        }

        private static void InitializeDb (DatabaseContext databaseContext) {
            var country = databaseContext.Countries.FirstOrDefault();
            if (country == null) {
                country = new Country { Name = "Hrvatska" };
                databaseContext.Countries.Add(country);
            }
            var city = databaseContext.Cities.FirstOrDefault();
            if (city == null) {
                city = new City { Name = "PEKA", Country = country };
                databaseContext.Cities.Add(city);
            }
            databaseContext.SaveChanges();
        }
        
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
