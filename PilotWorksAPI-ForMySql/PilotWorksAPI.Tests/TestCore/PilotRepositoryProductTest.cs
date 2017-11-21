using PilotWorksAPI.Core.DataLayer;
using PilotWorksAPI.Core.EntityLayer;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PilotWorksAPI.Tests.TestCore
{
    public class PilotRepositoryProductTest
    {
        [Fact]
        public async Task TestGetNoProductAsync_Core()
        {
            // Get repository
            var repository = RepositoryMocker.GetAdventureWorksRepository();

            // Product id = 0
            int id = 0;
            var entity = await repository.GetProductAsync(new Product { ProductID = id });
            Assert.True(entity == null);

            // Product id=400 (the number bigger enough that we cannot find out product item)
            id = 4000;
            entity = await repository.GetProductAsync(new Product { ProductID = id });
            Assert.True(entity == null);

            repository.Dispose();
        }
    }
}
