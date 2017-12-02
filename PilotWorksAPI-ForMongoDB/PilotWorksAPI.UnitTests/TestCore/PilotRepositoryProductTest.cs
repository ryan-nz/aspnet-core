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
            Repository.DeleteProductManyAsync("BI-808");
            Repository.DeleteProductManyAsync("BI-909");
        }

        [TestMethod]
        public async Task TestGetProductsAsync_Core()
        {
            // Test getting product list function
            IList<Product> list = (IList<Product>)await Repository.GetAllProductsAsync();
            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count >= 2);
        }

        [TestMethod]
        public async Task TestGetProductAsync_Core()
        {
            // Test getting one product function
            Product product = await Repository.GetProductAsync("BI-909");
            Assert.IsNotNull(product);

            // Test getting one product function
            product = await Repository.GetProductAsync("BI-808");
            Assert.IsNotNull(product);
        }

        [TestMethod]
        public async Task TestAddProductAsync_Core()
        {
            string strProductNumber = "MB-787";
            Product product = await Repository.GetProductAsync(strProductNumber);
            if (product == null)
            {
                product = new Product();
                // Prepare product entity to add into MongoDB
                product.ProductName = "MotoBike";
                product.ProductNumber = strProductNumber;
                product.Price = 2999.99;

                // Test adding function
                await Repository.AddProductAsync(product);
            }

            // Test getting one product function
            product = await Repository.GetProductAsync(strProductNumber);
            Assert.IsNotNull(product);
        }

        [TestMethod]
        public void TestDeleteProduct_Core()
        {
            // Remove done product with "BI-808" product number
            Repository.DeleteProduct("BI-808");

            // Remove done product with "BI-909" product number
            Repository.DeleteProduct("BI-909");

            // Test getting one product function
            Product product = Repository.GetProduct("BI-808");
            Assert.IsNull(product);
        }

        [TestMethod]
        public async Task TestUpdateProductAsync_Core()
        {
            string strOriginalProductNumber = "BI-909";
            Product product = Repository.GetProduct(strOriginalProductNumber);
            if (product == null)
            {
                product = new Product();
                // Prepare product entity to add into MongoDB
                product.ProductName = "MotoBike";
                product.ProductNumber = strOriginalProductNumber;
                product.Price = 2999.99;

                // Test adding function
                Repository.AddProduct(product);
            }

            // Reset product properties
            product.ProductName = "Surfboard";
            product.ProductNumber = "SF-555";
            product.Price = 66.66;

            bool success = await Repository.UpdateProductAsync(product);
            Assert.IsTrue(success);
        }

        public void TestDeleteAllProduct_Core()
        {
            // Remove all documents (products)
            Repository.DeleteAllProductsAsync();
        }
    }
}
