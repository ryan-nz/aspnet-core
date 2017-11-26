using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PilotWorksAPI.Controllers;
using PilotWorksAPI.Responses;
using System.Collections.Generic;

namespace PilotWorksAPI.UnitTests.TestAPI
{
    [TestClass]
    public class TestApiProduct
    {
        [TestMethod]
        public void TestGet()
        {
            // Get repository
            var repository = RepositoryMocker.GetAdventureWorksRepository();
            var controller = new ProductionController(repository);

            // Get data
            var response = controller.GetProduct("address") as ObjectResult;
            var value = response.Value as ISingleModelResponse<KeyValuePair<string, string>>;

            controller.Dispose();

            Assert.IsTrue(value.Model.Value == "pakuranga");

            // Assert completing
            Assert.IsFalse(value.HadError);
        }

        [TestMethod]
        public void TestPost()
        {
            // Get repository
            var repository = RepositoryMocker.GetAdventureWorksRepository();
            var controller = new ProductionController(repository);

            // Add one data
            var response = controller.Post("new000", "value001") as ObjectResult;
            var value = response.Value as ISingleModelResponse<KeyValuePair<string, string>>;

            controller.Dispose();

            Assert.IsTrue(value.Model.Value == "value001");

            // Assert completing
            Assert.IsFalse(value.HadError);

            // Delete the added data at the end
            response = controller.Delete("new000") as ObjectResult;
            // Assert completing
            Assert.IsFalse(value.HadError);
        }

        [TestMethod]
        public void TestPut()
        {
            // Get repository
            var repository = RepositoryMocker.GetAdventureWorksRepository();
            var controller = new ProductionController(repository);

            // Add one data
            var response = controller.Post("new000", "value001") as ObjectResult;
            var value = response.Value as ISingleModelResponse<KeyValuePair<string, string>>;

            Assert.IsTrue(value.Model.Value == "value001");

            // Assert completing
            Assert.IsFalse(value.HadError);


            // Put/Update data
            response = controller.Put("new000", "value001-modified") as ObjectResult;
            value = response.Value as ISingleModelResponse<KeyValuePair<string, string>>;

            Assert.IsTrue(value.Model.Value == "value001-modified");

            // Delete the added data at the end
            response = controller.Delete("new000") as ObjectResult;
            // Assert completing
            Assert.IsFalse(value.HadError);

            controller.Dispose();
        }

        [TestMethod]
        public void TestDelete()
        {
            TestPost();

            // To confirm whether deleted
            var repository = RepositoryMocker.GetAdventureWorksRepository();
            var controller = new ProductionController(repository);

            // Get data
            var response = controller.GetProduct("new000") as ObjectResult;
            var value = response.Value as ISingleModelResponse<KeyValuePair<string, string>>;

            controller.Dispose();

            Assert.IsTrue(value.Model.Value == null);

            // Assert completing
            Assert.IsTrue(value.HadError);
        }
    }
}
