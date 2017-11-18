using Microsoft.AspNetCore.Mvc;
using PilotWorksAPI.Controllers;
using PilotWorksAPI.Responses;
using PilotWorksAPI.ViewModels;
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

        // Test to update data

        // Test to delete data
    }
}
