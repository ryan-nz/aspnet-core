using PilotWorksAPI.Core.DataEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PilotWorksAPI.Core.DataLayer
{
    public interface IPilotWorksRepository
    {
        Task<List<Product>> GetProducts();

        Task<Product> GetProduct(string number);

        Task AddProduct(Product product);

        Task UpdateProduct(Product product);

        Task DeleteProduct(string productNumber);
    }
}
