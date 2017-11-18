using PilotWorksAPI.Core.EntityLayer;
using System.Linq;

namespace PilotWorksAPI.Core.DataLayer
{
    public static class DbInitializer
    {
        public static void Initialize(PilotWorksDbContext context)
        {
            context.Database.EnsureCreated();

            //var query = DbContext.Set<Product>().Skip((pageNumber - 1) * pageSize).Take(pageSize);

            var query = context.Set<Product>();

            // Look for any products.
            if (query.Count() > 0)
            {
                return;   // DB has been seeded
            }

            var products = new Product[]
            {
                new Product{ Name = "Ball", ProductNumber = "AR-1234" },
                new Product{ Name = "Pad", ProductNumber = "BA-8256" },
                new Product{ Name = "Heaphone", ProductNumber = "CA-1250" }
            };

            foreach (Product product in products)
            {
                context.Set<Product>().Add(product);
            }
            context.SaveChanges();
        }
    }
}
