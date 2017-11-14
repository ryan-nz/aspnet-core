using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorksAPI.Core.EntityLayer;

namespace AdventureWorksAPI.Core.DataLayer
{
    public class AdventureWorksRepository : IAdventureWorksRepository
    {
        private readonly AdventureWorksDbContext DbContext;
        private Boolean Disposed;

        public AdventureWorksRepository(AdventureWorksDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Dispose()
        {
            if (!Disposed)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();

                    Disposed = true;
                }
            }
        }

        public Task<Product> AddProductAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<Product> DeleteProductAsync(Product changes)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> GetProducts(int pageSize, int pageNumber, string name)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateProductAsync(Product changes)
        {
            throw new NotImplementedException();
        }
    }
}
