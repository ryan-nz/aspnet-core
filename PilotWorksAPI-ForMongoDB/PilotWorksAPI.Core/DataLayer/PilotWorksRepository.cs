using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PilotWorksAPI.Core.DataEntity;
using System.Threading.Tasks;
using System.Linq;

namespace PilotWorksAPI.Core.DataLayer
{
    public class PilotWorksRepository : IPilotWorksRepository
    {
        private readonly MongoDB.Driver.IMongoDatabase _db;
        private readonly string _mongoUrl;
        private readonly string _collectionProduct;

        public PilotWorksRepository(IOptions<AppSettings> appSettings)
        {
            _mongoUrl = appSettings.Value.DefaultConnection;

            MongoDB.Driver.MongoUrl mongoUrl = new MongoDB.Driver.MongoUrl(_mongoUrl);
            MongoDB.Driver.MongoClient client = new MongoDB.Driver.MongoClient(mongoUrl);
            _db = client.GetDatabase(appSettings.Value.Database);

            _collectionProduct = "product";
        }

        public IMongoDatabase Database()
        {
            return _db;
        }

        protected IMongoCollection<Product> GetCollection()
        {
            IMongoCollection<Product> col = _db.GetCollection<Product>(_collectionProduct);
            return col;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await GetCollection().Find(_ => true).ToListAsync();
        }

        public async Task<Product> GetProduct(string number)
        {
            return await GetCollection().Find(x => x.ProductNumber.Contains(number)).FirstOrDefaultAsync();
        }

        public async Task AddProduct(Product product)
        {
            await GetCollection().InsertOneAsync(product);
        }

        public async Task DeleteProduct(string productNumber)
        {
            await GetCollection().DeleteManyAsync(x => x.ProductNumber == productNumber);
        }

        public async Task UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteAllProducts()
        {
            GetCollection().DeleteMany(_ => true);
        }
    }
}
