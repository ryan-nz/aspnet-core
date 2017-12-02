using Microsoft.Extensions.Options;
using PilotWorksAPI.Core.DataLayer;

namespace PilotWorksAPI.UnitTests
{
    public static class RepositoryMocker
    {
        public static IPilotWorksRepository GetAdventureWorksRepository()
        {
            AppSettings appSettings = new AppSettings();
            //appSettings.ConnectionString = "server=(local);database=MyWorksAPI;integrated security=yes;";
            appSettings.MongoServer = "mongodb://192.168.99.100:27017";
            appSettings.Database = "karaka";

            var iappSettings = Options.Create(appSettings);

            return new PilotWorksRepository(iappSettings);
        }
    }
}
