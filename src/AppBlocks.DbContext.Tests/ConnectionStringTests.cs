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

        [TestMethod]
        public void ConnectionStringAppBlocksEnvVariableTest()
        {
            var config = Config.Factory.GetConfig();
            Assert.IsFalse(config == null);
            var connectionString = config.GetConnectionString("AppBlocks");
            Assert.IsFalse(string.IsNullOrEmpty(connectionString));
            Assert.IsTrue(connectionString != "xx");
        }
    }
}