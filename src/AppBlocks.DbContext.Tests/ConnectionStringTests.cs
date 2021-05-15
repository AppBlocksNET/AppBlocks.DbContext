using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppBlocks.DbContext.Tests
{
    [TestClass]
    public class ConnectionStringTests
    {
        [TestMethod]
        public void ConnectionStringDefaultTest()
        {
            var config = Config.Factory.GetConfig();
            Assert.IsFalse(config == null);

            Assert.IsFalse(string.IsNullOrEmpty(config.GetConnectionString("DefaultConnection")));
        }

        [TestMethod]
        public void ConnectionStringAppBlocksTest()
        {
            var config = Config.Factory.GetConfig();
            Assert.IsFalse(config == null);

            Assert.IsFalse(string.IsNullOrEmpty(config.GetConnectionString("AppBlocks")));
        }
    }
}