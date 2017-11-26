using System.Collections.Generic;

namespace PilotWorksAPI.Core.DataLayer
{
    public interface IPilotWorksRepository : System.IDisposable
    {
        StackExchange.Redis.ConnectionMultiplexer Connection();

        IEnumerable<KeyValuePair<string, string>> GetProducts();

        KeyValuePair<string, string> GetProduct(string key);

        bool AddProduct(string key, string value);

        bool UpdateProduct(string key, string value);

        bool DeleteProduct(string key);
    }
}
