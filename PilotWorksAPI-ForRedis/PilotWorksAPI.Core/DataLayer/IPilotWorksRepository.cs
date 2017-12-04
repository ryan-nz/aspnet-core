using System.Collections.Generic;

namespace PilotWorksAPI.Core.DataLayer
{
    public interface IPilotWorksRepository : System.IDisposable
    {
        IList<KeyValuePair<string, string>> GetAllProducts();

        KeyValuePair<string, string> GetProduct(string key);

        bool AddProduct(string key, string value);

        bool UpdateProduct(string key, string value);

        bool DeleteProduct(string key);
    }
}
