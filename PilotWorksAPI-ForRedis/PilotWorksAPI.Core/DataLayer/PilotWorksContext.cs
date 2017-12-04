using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System;

namespace PilotWorksAPI.Core.DataLayer
{
    public class PilotWorksContext : IDisposable
    {
        //private readonly Lazy<ConnectionMultiplexer> _connection;
        private readonly ConnectionMultiplexer _connection;
        private readonly string _defaultConnection;
        private bool Disposed { get; set; }

        public PilotWorksContext(IOptions<AppSettings> appSettings)
        {
            _defaultConnection = appSettings.Value.RedisConnection;
            _connection = ConnectionMultiplexer.Connect(_defaultConnection);
        }

        public void Dispose()
        {
            if (!Disposed)
            {
                if (_connection != null)
                {
                    _connection.Dispose();
                    Disposed = false;
                }
            }
        }

        public ConnectionMultiplexer Connection()
        {
            return _connection;
        }

        public IDatabase GetDatabase()
        {
            return _connection.GetDatabase();
        }

        public IServer GetServer()
        {
            IServer server = _connection.GetServer(_defaultConnection);
            return server;
        }
    }
}
