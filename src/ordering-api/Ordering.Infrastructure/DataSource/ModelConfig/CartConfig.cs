using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.DataSource.ModelConfig
{
    public class CartConfig : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.Property(b => b.Id).IsRequired();
            builder.HasKey(b => b.Id);

            builder.Property(b => b.CustomerId).IsRequired();
            builder.HasIndex(b => b.CustomerId);

            builder.HasMany(b => b.Items)
                .WithOne()
                .HasForeignKey(b => b.CartId);
        }
    }
}
