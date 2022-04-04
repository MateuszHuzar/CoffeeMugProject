using CoffeeMugProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeMugProject.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
