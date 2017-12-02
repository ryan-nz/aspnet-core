using MongoDB.Bson;
using PilotWorksAPI.Core.DataEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PilotWorksAPI.Core.DataLayer
{
    public interface IPilotWorksRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();

        Product GetProduct(string number);

        Task<Product> GetProductAsync(string number);

        void AddProduct(Product product);

        Task AddProductAsync(Product product);

        bool DeleteProduct(string productNumber);

        Task<bool> DeleteProductAsync(string productNumber);

        Task<bool> DeleteProductManyAsync(string productNumber);

        Task<bool> UpdateProductAsync(Product product);

        bool DeleteAllProducts();

        Task<bool> DeleteAllProductsAsync();
    }
}
