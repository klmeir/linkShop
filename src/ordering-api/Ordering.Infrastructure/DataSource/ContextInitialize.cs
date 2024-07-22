using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.DataSource
{
    public class ContextInitialize
    {
        protected ContextInitialize() { }

        public static void Seed(IServiceProvider serviceProvider)
        {
            // migrate the database.  Best practice = in Main, using service scope
            using (var scope = serviceProvider.CreateScope())
            {

                try
                {                    
                    var context = scope.ServiceProvider.GetService<DataContext>();

                    context.Database.Migrate();

                    // for testing purposes                    
                    SeedCart(scope.ServiceProvider);
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<ContextInitialize>>();
                    logger.LogError(ex, "An error occurred while migrating the database.");
                }

            }

        }

        private static void SeedCart(IServiceProvider serviceProvider)
        {            
            var context = serviceProvider.GetService<DataContext>();

            var carts = context.Set<Cart>();
            if (!carts.Any()) {
                // Cart 1
                var cart1Items = new List<CartItem>
                {
                    new CartItem
                    {
                        ProductId = Guid.NewGuid(), // ProductId (ej. MacBook Pro 13-inch)
                        Quantity = 1,
                        Name = "MacBook Pro 13-inch",
                        Price = 1299.99m,
                        PictureFileName = "macbook_pro.jpg"
                    },
                    new CartItem
                    {
                        ProductId = Guid.NewGuid(), // ProductId (ej. iPhone 13 Pro Max)
                        Quantity = 2,
                        Name = "iPhone 13 Pro Max",
                        Price = 1099.99m,
                        PictureFileName = "iphone_13_pro_max.jpg"
                    }
                };
                carts.Add(new Cart(Guid.NewGuid(), Guid.NewGuid(), cart1Items));

                // Cart 2
                var cart2Items = new List<CartItem>
                {
                    new CartItem
                    {
                        ProductId = Guid.NewGuid(), // ProductId (ej. Samsung Galaxy Tab S7+)
                        Quantity = 1,
                        Name = "Samsung Galaxy Tab S7+",
                        Price = 849.99m,
                        PictureFileName = "galaxy_tab_s7_plus.jpg"
                    },
                    new CartItem
                    {
                        ProductId = Guid.NewGuid(), // ProductId (ej. Microsoft Surface Laptop 4)
                        Quantity = 1,
                        Name = "Microsoft Surface Laptop 4",
                        Price = 1299.99m,
                        PictureFileName = "surface_laptop_4.jpg"
                    }
                };
                carts.Add(new Cart(Guid.NewGuid(), Guid.NewGuid(), cart2Items));

                context.SaveChanges();
            }

        }

    }
}
