using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace PilotWorksAPI.Core.DataLayer
{
    public class PilotWorksRepository : IPilotWorksRepository
    {
        private readonly Lazy<ConnectionMultiplexer> _connection;
        private readonly string _defaultConnection;
        private bool Disposed;

        public PilotWorksRepository(IOptions<AppSettings> appSettings)
        {
            _defaultConnection = appSettings.Value.DefaultConnection;
            _connection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(_defaultConnection));
        }

        public void Dispose()
        {
            if (!Disposed)
            {
                if (_connection != null && _connection.Value != null)
                {
                    _connection.Value.Dispose();
                    Disposed = true;
                }
            }
        }

        public ConnectionMultiplexer Connection()
        {
            return _connection.Value;
        }

        public IEnumerable<KeyValuePair<string, string>> GetProducts()
        {
            var db = Connection().GetDatabase();
            IServer server = Connection().GetServer(_defaultConnection);
            var list = new List<KeyValuePair<String, String>>();
            foreach (var key in server.Keys())
            {
                string value = db.StringGet(key);
                list.Add(new KeyValuePair<string, string>(key, value));
            }

            return list;
        }

        public KeyValuePair<string, string> GetProduct(string key)
        {
            var db = Connection().GetDatabase();
            string value = db.StringGet(key);
            return new KeyValuePair<String, String>(key, value);
        }

        public bool AddProduct(string key, string value)
        {
            var db = Connection().GetDatabase();
            return db.StringSet(key, value);
        }

        public bool DeleteProduct(string key)
        {
            var db = Connection().GetDatabase();
            return db.KeyDelete(key);
        }

        public bool UpdateProduct(string key, string value)
        {
            var db = Connection().GetDatabase();
            string prevValue = db.StringGet(key);
            if (string.IsNullOrEmpty(value))
            {
                throw new KeyNotFoundException($"The key of '{key}' is not found.");
            }

            return db.StringSet(key, value);
        }
    }
}
