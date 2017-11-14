using AdventureWorksAPI.Core.DataLayer;
using Microsoft.Extensions.Options;

namespace AdventureWorksAPI.Tests
{
    public static class RepositoryMocker
    {
        public static IAdventureWorksRepository GetAdventureWorksRepository()
        {
            AppSettings appSettings = new AppSettings();
            appSettings.ConnectionString = "server=(local);database=AdventureWorks2012;integrated security=yes;";

            var iappSettings = Options.Create(appSettings);

            //return new AdventureWorksRepository(new AdventureWorksDbContext(iappSettings, new AdventureWorksEntityMapper()));
            return new AdventureWorksRepository(new AdventureWorksDbContext(iappSettings));
        }
    }
}
