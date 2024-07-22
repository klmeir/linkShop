using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.DataSource.ModelConfig
{
    public class ProductTypeConfig : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.Property(b => b.Id).IsRequired();
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Type).HasMaxLength(100).IsRequired();
        }
    }
}
