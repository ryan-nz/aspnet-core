
using Microsoft.Extensions.Options;
using PilotWorksAPI.Core.DataLayer;

namespace PilotWorksAPI.UnitTests
{
    public static class RepositoryMocker
    {
        public static IPilotWorksRepository GetAdventureWorksRepository()
        {
            AppSettings appSettings = new AppSettings();
            appSettings.RedisConnection = "192.168.99.100:6379";

            var iappSettings = Options.Create(appSettings);

            return new PilotWorksRepository(iappSettings);
        }
    }
}
