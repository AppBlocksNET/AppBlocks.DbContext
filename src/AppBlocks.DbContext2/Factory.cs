using AppBlocks.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppBlocks.DbContext
{
    public static class Factory
    {
        public static AppBlocksDbContext CreateDbContext(string connectionStringId = null)
        {
            return CreateDbContext(new[] { connectionStringId });
        }

        public static AppBlocksDbContext CreateDbContext(string[] args)
        {
            return new DesignTimeDbContextFactory().CreateDbContext(args);
        }

        public static string Sync()
        {
            return Sync(CreateDbContext(), CreateDbContext("AppBlocksAzure"));
        }

        public static string Sync(AppBlocksDbContext sourceDbContext, AppBlocksDbContext destinationDbContext, bool WhatIf = false)
        {
            var results = string.Empty;

            var sourceItems = sourceDbContext.Items.OrderBy(i => i.CreatorId).ToList();

            results += $"<tr><td>Items found:{sourceItems.Count} in {sourceDbContext.Database.CurrentTransaction.TransactionId}</td></tr>\r\n";

            var newItems = new List<Item>();
            var updatedItems = new List<Item>();

            var compareItems = true;
            var dirty = false;
            if (compareItems)
            {
                foreach (var item in sourceItems)
                {
                    var existingItem = destinationDbContext.Items.FirstOrDefault(i => i.Id == item.Id);
                    if (existingItem != null)
                    {
                        results += $"<tr><td>{item.Id}</td><td>{item.Name}</td><td>Already exists.</td></tr>\r\n";
                    }
                    else
                    {
                        results += $"<tr><td>{item.Id}</td><td>{item.Name}</td><td>Does not exist.</td></tr>\r\n";
                        if (!WhatIf)
                        {
                            dirty = true;
                            //shouldnt need to do this as long as creator is an actual item
                            //var creator = destinationDbContext.Items.FirstOrDefault(i => i.Id == item.CreatorId);
                            //if (creator == null)
                            //{
                            //    destinationDbContext.Items.Add(creator);
                            //}
                            //destinationDbContext.BulkInsert(item);
                            newItems.Add(item);
                        }
                    }
                }
            }
            if (dirty)
            {
                var recordsUpdated = 0;
                try
                {
                    //using EFCore.BulkExtensions;
                    //requires EFCore 3.1.8 and newers
                    //recordsUpdated = destinationDbContext.SaveChanges();
                    //destinationDbContext.BulkInsert(newItems);
                    recordsUpdated += newItems.Count;
                    results += $"<tr><td>Records Updated:{recordsUpdated}</td></tr>";
                }
                catch (Exception exception)
                {
                    results += $"<tr><td>Error saving {recordsUpdated} records:{exception}</td></tr>";
                }
            }
            return results;
        }

        //private async static Task CreateDbIfNotExists(IHost host)
        //{
        //    using (var scope = host.Services.CreateScope())
        //    {
        //        var services = scope.ServiceProvider;
        //        try
        //        {
        //            var context = services.GetRequiredService<AppBlocksDbContext>();
        //            context.Database.EnsureCreated();
        //            // DbInitializer.Initialize(context);
        //        }
        //        catch (Exception ex)
        //        {
        //            var logger = services.GetRequiredService<ILogger>();
        //            logger.LogError(ex, "An error occurred creating the DB.");
        //        }
        //    }
        //}
    }
}