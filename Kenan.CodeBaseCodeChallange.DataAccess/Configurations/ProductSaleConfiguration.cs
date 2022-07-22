using Kenan.CodeBaseCodeChallange.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kenan.CodeBaseCodeChallange.DataAccess.Configurations
{
    public class ProductSaleConfiguration : IEntityTypeConfiguration<ProductSale>
    {
        public void Configure(EntityTypeBuilder<ProductSale> builder)
        {
            builder.Property(x => x.CreatedAt).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.CustomerName).HasMaxLength(300).IsRequired();
            builder.HasOne<Product>(x => x.Product).WithMany(x => x.ProductSales).HasForeignKey(x => x.ProductId);
        }
    }
}
