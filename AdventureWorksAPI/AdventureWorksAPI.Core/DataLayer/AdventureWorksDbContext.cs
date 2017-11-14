using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace AdventureWorksAPI.Core.DataLayer
{
    public class AdventureWorksDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AdventureWorksDbContext(IOptions<AppSettings> appSettings)
        {
            ConnectionString = appSettings.Value.ConnectionString;
        }

        public String ConnectionString { get; }

        public IEntityMapper EntityMapper { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.MapProduct();
            EntityMapper.MapEntities(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
