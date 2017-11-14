using Microsoft.EntityFrameworkCore;

namespace AdventureWorksAPI.Core.DataLayer
{
    public static class ProductMap
    {
        public static ModelBuilder MapProduct(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<EntityLayer.Product>();

            entity.ToTable("Product", "Production");

            entity.HasKey(p => new { p.ProductID });

            entity.Property(p => p.ProductID).UseSqlServerIdentityColumn();

            return modelBuilder;
        }
    }
}
