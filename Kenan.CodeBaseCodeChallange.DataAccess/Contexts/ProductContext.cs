using Kenan.CodeBaseCodeChallange.DataAccess.Configurations;
using Kenan.CodeBaseCodeChallange.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kenan.CodeBaseCodeChallange.DataAccess.Contexts
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ProductSaleConfiguration());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSale> ProductSales { get; set; }
    }
}
