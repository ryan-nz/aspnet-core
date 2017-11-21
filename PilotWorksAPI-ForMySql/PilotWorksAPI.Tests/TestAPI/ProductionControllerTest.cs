using Microsoft.AspNetCore.Mvc;
using PilotWorksAPI.Controllers;
using PilotWorksAPI.Core.DataLayer;
using PilotWorksAPI.Responses;
using PilotWorksAPI.ViewModels;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PilotWorksAPI.Tests.TestAPI
{
    public class ProductionControllerTest
    {
        [Fact]
        public async Task TestGetProductsAsync()
        {
            // Get repository
            var repository = RepositoryMocker.GetAdventureWorksRepository();
            var controller = new ProductionController(repository);

            // Get products list
            var response = await controller.GetProductsAsync() as ObjectResult;
            var value = response.Value as IListModelResponse<ProductViewModel>;

            controller.Dispose();

            // Assert completing
            Assert.False(value.HadError);
        }

        [Fact]
        public async Task TestGetProductAsync()
        {
            // Get repository
            var repository = RepositoryMocker.GetAdventureWorksRepository();
            var controller = new ProductionController(repository);
            // Product id=1
            int id = 1;

            // Get a product with id=1
            var response = await controller.GetProductAsync(id) as ObjectResult;
            var value = response.Value as ISingleModelResponse<ProductViewModel>;

            repository.Dispose();

            // Assert completing
            Assert.False(value.HadError);
        }

        [Fact]
        public async Task TestGetNoneExistingProductAsync()
        {
            // Get repository
            var repository = RepositoryMocker.GetAdventureWorksRepository();
            var controller = new ProductionController(repository);
            // Product id=0 (or the number bigger enough that we cannot find out product item)
            int id = 0;

            // Get a product with id=1
            var response = await controller.GetProductAsync(id) as ObjectResult;
            var value = response.Value as ISingleModelResponse<ProductViewModel>;

            repository.Dispose();

            // Assert completing
            Assert.False(value.HadError);
        }

        // Test to add data
        [Fact]
        public async Task TestPostProductAsync()
        {
            // Get repository
            var repository = RepositoryMocker.GetAdventureWorksRepository();
            // Create Production Controller
            var controller = new ProductionController(repository);

            // Prepare dummy data to add (Post)
            ProductViewModel newRecord = new ProductViewModel
            {
                ProductName = $"New test product {DateTime.Now.Minute}{DateTime.Now.Second}{DateTime.Now.Millisecond}",
                ProductNumber = $"{DateTime.Now.Minute}{DateTime.Now.Second}{DateTime.Now.Millisecond}"
            };

            // Test to add data in ProductionController.Post
            var response = await controller.Post(newRecord) as ObjectResult;
            var value = response.Value as ISingleModelResponse<ProductViewModel>;

            repository.Dispose();

            // Assert completing
            Assert.False(value.HadError);
        }

        // Test to update data
        [Fact]
        public async Task TestPutProductAsync()
        {
            // Get repository
            IPilotWorksRepository repository = RepositoryMocker.GetAdventureWorksRepository();
            // Create Production Controller
            ProductionController controller = new ProductionController(repository);

            int id = 1;
            ProductViewModel updateRecord = new ProductViewModel
            {
                ProductID = id,
                ProductName = "New product test II",
                ProductNumber = "XYZ"
            };

            var response = await controller.Put(id, updateRecord) as ObjectResult;
            var value = response.Value as ISingleModelResponse<ProductViewModel>;

            repository.Dispose();

            // Assert
            Assert.False(value.HadError);
        }

        // Test to delete data
        [Fact]
        public async Task TestDeleteProductAsync()
        {
            // Get repository
            IPilotWorksRepository repository = RepositoryMocker.GetAdventureWorksRepository();
            // Create Production Controller
            ProductionController controller = new ProductionController(repository);

            int id = GetMaxProductID();
            // Delete the product with the max value of ID
            var response = await controller.Delete(id) as ObjectResult;
            var value = response.Value as ISingleModelResponse<ProductViewModel>;

            repository.Dispose();

            // Assert
            Assert.False(value.HadError);
        }

        private int GetMaxProductID()
        {
            // Get repository
            PilotWorksRepository repository = (PilotWorksRepository)RepositoryMocker.GetAdventureWorksRepository();

            // Get the max value of Product id
            int maxProductID = repository.GetMaxProductID();
            return maxProductID;
        }
    }
}
