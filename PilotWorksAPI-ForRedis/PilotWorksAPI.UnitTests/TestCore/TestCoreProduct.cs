using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PilotWorksAPI.Core.DataLayer;
using System.Threading.Tasks;

namespace PilotWorksAPI.UnitTests.TestCore
{
    [TestClass]
    public class TestCoreProduct
    {
        [TestMethod]
        public void TestGet_Core()
        {
            // Get repository
            IPilotWorksRepository repository = RepositoryMocker.GetAdventureWorksRepository();

            var entity = repository.GetProduct("address");
            Assert.IsTrue(entity.Value == "pakuranga");

            entity = repository.GetProduct("youraddr");
            Assert.IsTrue(entity.Value == "karaka");

            entity = repository.GetProduct("youraddr2");
            Assert.IsTrue(entity.Value == "pukeno");
        }

        [TestMethod]
        public void TestPost_Core()
        {
            // Get repository
            IPilotWorksRepository repository = RepositoryMocker.GetAdventureWorksRepository();

            Assert.IsTrue(repository.AddProduct("new000", "value000"));
            Assert.IsTrue(repository.GetProduct("new000").Value == "value000");
        }

        [TestMethod]
        public void TestPut_Core()
        {
            // Get repository
            IPilotWorksRepository repository = RepositoryMocker.GetAdventureWorksRepository();

            // Add firstly
            Assert.IsTrue(repository.AddProduct("new001", "value001"));
            Assert.IsTrue(repository.GetProduct("new001").Value == "value001");

            // Update
            Assert.IsTrue(repository.UpdateProduct("new001", "value001-modified"));
            Assert.IsTrue(repository.GetProduct("new001").Value == "value001-modified");
        }

        [TestMethod]
        public void TestDelete_Core()
        {
            // Get repository
            IPilotWorksRepository repository = RepositoryMocker.GetAdventureWorksRepository();

            Assert.IsTrue(repository.AddProduct("new002", "value002"));
            Assert.IsTrue(repository.DeleteProduct("new002"));
        }
    }
}
