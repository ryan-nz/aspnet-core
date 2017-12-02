using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PilotWorksAPI.Core.DataLayer;
using PilotWorksAPI.MongoDB.Controllers;
using PilotWorksAPI.MongoDB.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PilotWorksAPI.UnitTests.TestAPI
{
    [TestClass]
    public class SysAdminControllerTest
    {
        private static IPilotWorksRepository _repository;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            // Get repository
            _repository = RepositoryMocker.GetAdventureWorksRepository();
        }

        [TestMethod]
        public void TestSysAdminGet_API()
        {
            // Get repository
            var repository = RepositoryMocker.GetAdventureWorksRepository();
            var controller = new SysAdminController(repository);

            // Get products list
            var response = controller.Get("init") as ObjectResult;
            var value = response.Value as ISingleModelResponse<string>;

            controller.Dispose();

            // Assert completing
            Assert.IsFalse(value.HadError);
        }

        [TestMethod]
        public void TestSysAdminGet2_API()
        {
            // Get repository
            var repository = RepositoryMocker.GetAdventureWorksRepository();
            var controller = new SysAdminController(repository);

            // Get products list
            var response = controller.Get("none-init") as ObjectResult;
            var value = response.Value as ISingleModelResponse<string>;

            controller.Dispose();

            // Assert completing
            Assert.IsTrue(value.HadError);
        }
    }
}