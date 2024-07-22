using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.DataSource.ModelConfig
{
    public class ProductBrandConfig : IEntityTypeConfiguration<ProductBrand>
    {
        public void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
            builder.Property(b => b.Id).IsRequired();
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Brand).HasMaxLength(100).IsRequired();
        }
    }
}
