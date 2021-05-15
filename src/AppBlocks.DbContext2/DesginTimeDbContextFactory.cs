using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace AppBlocks.DbContext
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppBlocksDbContext>
    {
        public AppBlocksDbContext CreateDbContext(string[] args = null)
        {
            var connectionStringId = args != null && args.Length > 0 && args[0] != null ? args[0] : "AppBlocks"; //If this fails, we try DefaultConnection
            IConfigurationRoot configuration = Config.Factory.GetConfig();
            var connectionString = connectionStringId.IndexOf("=") != -1 ? connectionStringId : configuration.GetConnectionString(connectionStringId);
            ////$"Server=.\\;Database={typeof(AppBlocksDbContext).Namespace};Trusted_Connection=True;MultipleActiveResultSets=true;Application Name=AppBlocks.Web.Dev"

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("ConnectionString");
            }

            DbContextOptionsBuilder<AppBlocksDbContext> optionsBuilder = new DbContextOptionsBuilder<AppBlocksDbContext>()
                //.UseSqlite(connectionString);
                .UseSqlServer(connectionString, builder => builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null));
            if (true) //Environment.GetEnvironmentVariable("ENV") == development
            {
                optionsBuilder.EnableDetailedErrors(true);
                optionsBuilder.EnableSensitiveDataLogging(true);
            }
            return new AppBlocksDbContext(optionsBuilder.Options);
        }
    }
}