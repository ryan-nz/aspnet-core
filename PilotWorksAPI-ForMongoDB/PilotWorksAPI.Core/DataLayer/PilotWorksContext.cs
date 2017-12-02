using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PilotWorksAPI.Core.DataEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PilotWorksAPI.Core.DataLayer
{
    public class PilotWorksContext
    {
        private readonly IMongoDatabase _database = null;

        public PilotWorksContext(IOptions<AppSettings> settings)
        {
            var client = new MongoClient(settings.Value.MongoServer);
            if (client != null)
            {
                _database = client.GetDatabase(settings.Value.Database);
            }
        }

        public IMongoCollection<Product> Products
        {
            get
            {
                return _database.GetCollection<Product>("product");
            }
        }
    }
}
