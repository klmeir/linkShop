using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.DataSource.ModelConfig
{
    public class CartItemConfig : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.Property(b => b.Id).IsRequired();
            builder.HasKey(b => b.Id);

            builder.Property(b => b.ProductId).IsRequired();
            builder.Property(b => b.Name).HasMaxLength(50).IsRequired();
            builder.Property(b => b.Quantity).IsRequired();
            builder.Property(b => b.Price).IsRequired();
            builder.Property(b => b.PictureFileName).IsRequired();
            builder.Property(b => b.CartId).IsRequired();            
        }
    }
}
