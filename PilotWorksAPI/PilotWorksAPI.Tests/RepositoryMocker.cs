using PilotWorksAPI.Core.DataLayer;
using Microsoft.Extensions.Options;

namespace PilotWorksAPI.Tests
{
    public static class RepositoryMocker
    {
        public static IPilotWorksRepository GetAdventureWorksRepository()
        {
            AppSettings appSettings = new AppSettings();
            //appSettings.ConnectionString = "server=(local);database=MyWorksAPI;integrated security=yes;";
            appSettings.DefaultConnection = "Server=(localdb)\\mssqllocaldb;Database=MyWorksAPI;Trusted_Connection=True;MultipleActiveResultSets=true";

            var iappSettings = Options.Create(appSettings);

            return new PilotWorksRepository(new PilotWorksDbContext(iappSettings, new PilotWorksEntityMapper()));
        }
    }
}
