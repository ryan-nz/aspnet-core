using Microsoft.VisualStudio.TestTools.UnitTesting;
using PilotWorksAPI.Core.DataEntity;
using PilotWorksAPI.Core.DataLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PilotWorksAPI.UnitTests.TestCore
{
    [TestClass]
    public class PilotRepositoryProductTest
    {
        private static IPilotWorksRepository _repository;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            // Get repository
            _repository = RepositoryMocker.GetAdventureWorksRepository();
        }

        private IPilotWorksRepository Repository
        {
            get { return _repository; }
        }

        [TestInitialize]
        public void TestInit()
        {
            // Prepare product entity to add into MongoDB
            Product product = new Product();
            product.ProductName = "Bicycle";
            product.ProductNumber = "BI-909";
            product.Price = 199.99;

            // Test adding function
            Repository.AddProduct(product);

            // Prepare product entity to add into MongoDB
            product = new Product();
            product.ProductName = "Bicycle";
            product.ProductNumber = "BI-808";
            product.Price = 188.88;

            // Test adding function
            Repository.AddProduct(product);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Repository.DeleteProduct("BI-808");
            Repository.DeleteProduct("BI-909");
        }

        [TestMethod]
        public async Task TestGetProducts_Core()
        {
            // Test getting product list function
            List<Product> list = await Repository.GetProducts();
            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count >= 2);
        }

        [TestMethod]
        public async Task TestGetProduct_Core()
        {
            // Test getting one product function
            Product product = await Repository.GetProduct("BI-909");
            Assert.IsNotNull(product);

            // Test getting one product function
            product = await Repository.GetProduct("BI-808");
            Assert.IsNotNull(product);
        }

        [TestMethod]
        public async Task TestAddProduct_Core()
        {
            string strProductNumber = "MB-777";
            Product product = await Repository.GetProduct(strProductNumber);
            if (product == null)
            {
                product = new Product();
                // Prepare product entity to add into MongoDB
                product.ProductName = "MotoBike";
                product.ProductNumber = strProductNumber;
                product.Price = 2999.99;

                // Test adding function
                await Repository.AddProduct(product);
            }

            // Test getting one product function
            product = await Repository.GetProduct(strProductNumber);
            Assert.IsNotNull(product);
        }

        [TestMethod]
        public async Task TestDeleteProduct_Core()
        {
            // Remove done product with "BI-808" product number
            await Repository.DeleteProduct("BI-808");

            // Remove done product with "BI-909" product number
            await Repository.DeleteProduct("BI-909");

            // Test getting one product function
            Product product = await Repository.GetProduct("BI-808");
            Assert.IsNull(product);
        }

        public void TestDeleteAllProduct_Core()
        {
            // Remove all documents (products)
            (Repository as PilotWorksRepository).DeleteAllProducts();
        }
    }
}
