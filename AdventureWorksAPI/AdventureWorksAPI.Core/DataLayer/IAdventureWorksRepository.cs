using AdventureWorksAPI.Core.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksAPI.Core.DataLayer
{
    public interface IAdventureWorksRepository : IDisposable
    {
        IQueryable<Product> GetProducts(Int32 pageSize, Int32 pageNumber, String name);

        Task<Product> GetProductAsync(Product entity);

        Task<Product> AddProductAsync(Product entity);

        Task<Product> UpdateProductAsync(Product changes);

        Task<Product> DeleteProductAsync(Product changes);
    }
}
