using AppBlocks.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace AppBlocks.DbContext.Tests
{
    [TestClass]
    public class DataTests
    {
        [TestMethod]
        public void HomeTest()
        {
            Item item = null;
            using (AppBlocksDbContext dbContext = Factory.CreateDbContext())
            {
                item = dbContext?.Items?.FirstOrDefault(i => i.Name == "Home");
            }
            Assert.IsNotNull(item, "no one's home");
        }

        [TestMethod]
        public void ItemsCountTest()
        {
            int? itemsCount = 0;
            using (AppBlocksDbContext dbContext = Factory.CreateDbContext())
            {
                itemsCount = dbContext.Items?.Count();
            }
            Assert.IsNotNull(itemsCount > 0, $"Count:{itemsCount}");
        }

        [TestMethod]
        public void FullPathTest()
        {
            Item item = null;
            using (AppBlocksDbContext dbContext = Factory.CreateDbContext())
            {
                item = dbContext.Items.FirstOrDefault();
            }
            Assert.IsNotNull(item);
            Assert.IsTrue(string.IsNullOrEmpty(item.FullPath), item.FullPath);
        }

        [TestMethod]
        public void RootFullPathTest()
        {
            Item item = null;
            using (AppBlocksDbContext dbContext = Factory.CreateDbContext())
            {
                item = dbContext.Items.OrderBy(i => i.FullPath).FirstOrDefault();
            }
            Assert.IsNotNull(item);
            Assert.IsTrue(string.IsNullOrEmpty(item.FullPath), $"FullPath:{item.FullPath}");
        }


        [TestMethod]
        public void SystemTest()
        {
            Item item = null;
            using (AppBlocksDbContext dbContext = Factory.CreateDbContext())
            {
                item = dbContext?.Items?.FirstOrDefault(i => i.Name == "System");
            }

            Assert.IsNull(item, "all systems are not go");
        }


    }
}