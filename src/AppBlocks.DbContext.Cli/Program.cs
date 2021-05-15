using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

namespace AppBlocks.DbContext.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            //await (CreateHostBuilder(args)).Build();
            //var host = await CreateHostBuilder(args).Build();

            var host = CreateHostBuilder(args).Build();

            //Factory.CreateDbIfNotExists(host).Result;

            host.RunAsync();
            //host.Run();

            using (AppBlocksDbContext dbContext = Factory.CreateDbContext())
            {
                var Migrate = false;
                if (Migrate)
                {
                    dbContext.Database.Migrate();
                }
                //sc.Items.AddRange
                //(
                //    new Item { Name = "Home" }
                //);

                //sc.SaveChanges();

                Console.WriteLine($"Items found:{dbContext.Items.Count()}");

                var root = dbContext.Items.OrderBy(i => i.FullPath).FirstOrDefault();
                Console.WriteLine($"Root:{root?.Name}");


                var home = dbContext.Items.FirstOrDefault(i => i.Name == "Home");
                Console.WriteLine($"Home:{home?.Name}");

                using (var _destinationContext = Factory.CreateDbContext())
                {
                    home = _destinationContext.Items.FirstOrDefault(i => i.Name == "Home");
                    Console.WriteLine($"Destination:{home?.Name}:{home?.Id}");
                }


                var Sync = false;

                if (Sync)
                {
                    Console.Write(Factory.Sync());

                    Console.Write("\r\n\r\nPress any key to exit.");
                    Console.ReadKey();
                }
            }
        }


        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                IConfigurationRoot configuration = Config.Factory.GetConfig();
                string connectionString = configuration.GetConnectionString(typeof(AppBlocksDbContext).Namespace);

                try
                {
                    Console.WriteLine($"Connecting to: {connectionString}");
                    services.AddDbContextPool<AppBlocksDbContext>(opt => opt.UseSqlServer(connectionString));
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"ERROR {exception}");
                }

                services.AddHostedService<HostedService>();
                //services.AddHostedService<AppBlocksDbContext>();

                //Register services
                //services.AddTransient<AppBlocksDbContext>();
                services.AddTransient<HostedService>();
            });
    }
}
