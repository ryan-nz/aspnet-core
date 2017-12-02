using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using PilotWorksAPI.Core.DataEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PilotWorksAPI.Core.DataLayer
{
    public class PilotWorksRepository : IPilotWorksRepository
    {
        private readonly PilotWorksContext _context = null;

        public PilotWorksRepository(IOptions<AppSettings> appSettings)
        {
            _context = new PilotWorksContext(appSettings);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            try
            {
                return await _context.Products.Find(_ => true).ToListAsync();
            }
            catch (System.Exception ex)
            {
                // log out exception here
                throw ex;
            }
        }

        public Product GetProduct(string number)
        {
            try
            {
                return _context.Products.Find(x => x.ProductNumber.Equals(number)).FirstOrDefault();
            }
            catch (System.Exception ex)
            {
                // log out exception here
                throw ex;
            }
        }

        public async Task<Product> GetProductAsync(string number)
        {
            try
            {
                return await _context.Products.Find(x => x.ProductNumber.Equals(number)).FirstOrDefaultAsync();
            }
            catch (System.Exception ex)
            {
                // log out exception here
                throw ex;
            }
        }

        public void AddProduct(Product product)
        {
            try
            {
                _context.Products.InsertOne(product);
            }
            catch (System.Exception ex)
            {
                // log out exception here
                throw ex;
            }
        }

        public async Task AddProductAsync(Product product)
        {
            try
            {
                await _context.Products.InsertOneAsync(product);
            }
            catch (System.Exception ex)
            {
                // log out exception here
                throw ex;
            }
        }

        public bool DeleteProduct(string productNumber)
        {
            try
            {
                DeleteResult deleteResult = _context.Products.DeleteOne(item => item.ProductNumber == productNumber);
                return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
            }
            catch (System.Exception ex)
            {
                // log out exception here
                throw ex;
            }
        }

        public async Task<bool> DeleteProductAsync(string productNumber)
        {
            try
            {
                DeleteResult deleteResult = await _context.Products.DeleteOneAsync(item => item.ProductNumber == productNumber);
                return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
            }
            catch (System.Exception ex)
            {
                // log out exception here
                throw ex;
            }
        }

        public async Task<bool> DeleteProductManyAsync(string productNumber)
        {
            try
            {
                DeleteResult deleteResult = await _context.Products.DeleteManyAsync(item => item.ProductNumber == productNumber);
                return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
            }
            catch (System.Exception ex)
            {
                // log out exception here
                throw ex;
            }
        }

        public async Task<bool> UpdateProductAsync(Product item)
        {
            try
            {
                ReplaceOneResult replaceResult = await _context.Products.ReplaceOneAsync(
                    x => x.Id == item.Id  //update filter
                    , item                                      //update values
                    , new UpdateOptions { IsUpsert = true });   //update options

                return replaceResult.IsAcknowledged && replaceResult.ModifiedCount > 0;
            }
            catch (System.Exception ex)
            {
                // log out exception here
                throw ex;
            }
        }

        public bool DeleteAllProducts()
        {
            try
            {
                DeleteResult deleteResult = _context.Products.DeleteMany(_ => true);

                return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
            }
            catch (System.Exception ex)
            {
                // log out exception here
                throw ex;
            }
        }

        public async Task<bool> DeleteAllProductsAsync()
        {
            try
            {
                DeleteResult deleteResult = await _context.Products.DeleteManyAsync(_ => true);

                return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
            }
            catch (System.Exception ex)
            {
                // log out exception here
                throw ex;
            }
        }
    }
}
