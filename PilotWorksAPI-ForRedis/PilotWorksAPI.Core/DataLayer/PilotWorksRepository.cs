using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System;
using System.Collections.Generic;

namespace PilotWorksAPI.Core.DataLayer
{
    public class PilotWorksRepository : IPilotWorksRepository
    {
        private readonly PilotWorksDbContext _context = null;
        private bool Disposed;

        public PilotWorksRepository(IOptions<AppSettings> appSettings)
        {
            _context = new PilotWorksDbContext(appSettings);
        }

        public void Dispose()
        {
            if (!Disposed)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    Disposed = true;
                }
            }
        }

        private IDatabase Database
        {
            get
            {
                return _context.GetDatabase();
            }
        }

        public IList<KeyValuePair<string, string>> GetAllProducts()
        {
            IServer server = _context.GetServer();
            var list = new List<KeyValuePair<String, String>>();
            foreach (var key in server.Keys())
            {
                string value = Database.StringGet(key);
                list.Add(new KeyValuePair<string, string>(key, value));
            }

            return list;
        }

        public KeyValuePair<string, string> GetProduct(string key)
        {
            string value = Database.StringGet(key);
            return new KeyValuePair<String, String>(key, value);
        }

        public bool AddProduct(string key, string value)
        {
            return Database.StringSet(key, value);
        }

        public bool DeleteProduct(string key)
        {
            return Database.KeyDelete(key);
        }

        public bool UpdateProduct(string key, string value)
        {
            string prevValue = Database.StringGet(key);
            if (string.IsNullOrEmpty(value))
            {
                throw new KeyNotFoundException($"The key of '{key}' is not found.");
            }

            return Database.StringSet(key, value);
        }
    }
}
