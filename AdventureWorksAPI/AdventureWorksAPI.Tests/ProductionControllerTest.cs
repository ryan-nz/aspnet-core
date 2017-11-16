using AdventureWorksAPI.Controllers;
using AdventureWorksAPI.Responses;
using AdventureWorksAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksAPI.Tests
{
    public class ProductionControllerTest
    {
        [Fact]
        public async Task TestGetProductsAsync()
        {
            // Arrange
            var repository = RepositoryMocker.GetAdventureWorksRepository();
            var controller = new ProductionController(repository);

            // Act
            var response = await controller.GetProductsAsync() as ObjectResult;
            var value = response.Value as IListModelResponse<ProductViewModel>;

            controller.Dispose();

            // Assert
            Assert.False(value.HadError);
        }
    }
}
