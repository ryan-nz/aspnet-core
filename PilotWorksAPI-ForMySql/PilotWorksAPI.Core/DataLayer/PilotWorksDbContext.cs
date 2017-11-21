using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace PilotWorksAPI.Core.DataLayer
{
    public class PilotWorksDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public PilotWorksDbContext(IOptions<AppSettings> appSettings, IEntityMapper entityMapper)
        {
            ConnectionString = appSettings.Value.DefaultConnection;
            EntityMapper = entityMapper;
        }

        public String ConnectionString { get; }

        public IEntityMapper EntityMapper { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // The following code commented out is for SQL Server
            //optionsBuilder.UseSqlServer(ConnectionString);

            // The following added code is for MySql
            optionsBuilder.UseMySql(ConnectionString);

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
