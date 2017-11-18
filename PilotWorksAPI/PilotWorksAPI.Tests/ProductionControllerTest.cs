using PilotWorksAPI.Controllers;
using PilotWorksAPI.Responses;
using PilotWorksAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PilotWorksAPI.Tests
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

            // Assert
            Assert.False(value.HadError);
        }
    }
}
