using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using AdventureWorksAPI.Core.DataLayer;

namespace AdventureWorksAPI.Core.DataLayer
{
    public class AdventureWorksDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AdventureWorksDbContext(IOptions<AppSettings> appSettings)
        {
            ConnectionString = appSettings.Value.ConnectionString;
        }

        public String ConnectionString { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.MapProduct();

            base.OnModelCreating(modelBuilder);
        }
    }
}
