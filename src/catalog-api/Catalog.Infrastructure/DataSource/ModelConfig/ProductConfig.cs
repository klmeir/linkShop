using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Catalog.Domain.Entities;

namespace Catalog.Infrastructure.DataSource.ModelConfig
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(b => b.Id).IsRequired();
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name).HasMaxLength(50).IsRequired();
            builder.HasIndex(b => b.Name);
            builder.Property(b => b.Description).IsRequired();
            builder.Property(b => b.Price).IsRequired();
            builder.Property(b => b.PictureFileName).IsRequired();
            builder.Property(b => b.ProductTypeId).IsRequired();
            builder.Property(b => b.ProductBrandId).IsRequired();
            builder.Property(b => b.AvailableStock).IsRequired();

            builder.HasOne(b => b.ProductType)
                .WithMany()
                .HasForeignKey(b => b.ProductTypeId);

            builder.HasOne(b => b.ProductBrand)
                .WithMany()
                .HasForeignKey(b => b.ProductBrandId);
        }
    }
}
