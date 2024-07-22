using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Catalog.Infrastructure.DataSource
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
                    SeedProducts(scope.ServiceProvider);
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<ContextInitialize>>();
                    logger.LogError(ex, "An error occurred while migrating the database.");
                }

            }

        }

        private static void SeedProducts(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<DataContext>();
            // Initialize product Brands
            Guid appleId = Guid.NewGuid();
            Guid samsungId = Guid.NewGuid();
            Guid microsoftId = Guid.NewGuid();
            Guid sonyId = Guid.NewGuid();
            Guid lgId = Guid.NewGuid();

            // Initialize produc Types
            Guid laptopId = Guid.NewGuid();
            Guid smartphoneId = Guid.NewGuid();
            Guid tabletId = Guid.NewGuid();
            Guid monitorId = Guid.NewGuid();
            Guid keyboardId = Guid.NewGuid();
            Guid smartwatchId = Guid.NewGuid();
            Guid headphonesId = Guid.NewGuid();
            Guid audioSystemId = Guid.NewGuid();
            Guid videoGamesId = Guid.NewGuid();


            var producTypes = context.Set<ProductType>();
            if (!producTypes.Any())
            {
                var productTypeList = new List<ProductType>
                {
                    new ProductType { Id = laptopId, Type = "Laptop" },
                    new ProductType { Id = smartphoneId, Type = "Smartphone" },
                    new ProductType { Id = tabletId, Type = "Tablet" },
                    new ProductType { Id = monitorId, Type = "Monitor" },
                    new ProductType { Id = keyboardId, Type = "Keyboard" },
                    new ProductType { Id = smartwatchId, Type = "Smartwatch" },
                    new ProductType { Id = headphonesId, Type = "Headphones" },
                    new ProductType { Id = audioSystemId, Type = "Audio System" },
                    new ProductType { Id = videoGamesId, Type = "Video Games" }
                };

                producTypes.AddRange(productTypeList);
                context.SaveChanges();
            }

            var productBrands = context.Set<ProductBrand>();
            if (!productBrands.Any())
            {
                var productBrandList = new List<ProductBrand>
                {
                    new ProductBrand { Id = appleId, Brand = "Apple" },
                    new ProductBrand { Id = samsungId, Brand = "Samsung" },
                    new ProductBrand { Id = microsoftId, Brand = "Microsoft" },
                    new ProductBrand { Id = sonyId, Brand = "Sony" },
                    new ProductBrand { Id = lgId, Brand = "LG" }
                };

                productBrands.AddRange(productBrandList);
                context.SaveChanges();
            }

            var products = context.Set<Product>();
            if (!products.Any())
            {
                var productList = new List<Product>
                {
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "MacBook Pro 13-inch",
                        Description = "Apple MacBook Pro with M1 Chip",
                        Price = 1299.99m,
                        PictureFileName = "macbook_pro.jpg",
                        AvailableStock = 10,
                        ProductBrandId = appleId,
                        ProductTypeId = laptopId
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "iPhone 13 Pro Max",
                        Description = "Apple iPhone 13 Pro Max",
                        Price = 1099.99m,
                        PictureFileName = "iphone_13_pro_max.jpg",
                        AvailableStock = 15,
                        ProductBrandId = appleId,
                        ProductTypeId = smartphoneId
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Samsung Galaxy Tab S7+",
                        Description = "Samsung Galaxy Tab S7+ 12.4\"",
                        Price = 849.99m,
                        PictureFileName = "galaxy_tab_s7_plus.jpg",
                        AvailableStock = 20,
                        ProductBrandId = samsungId,
                        ProductTypeId = tabletId
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Microsoft Surface Laptop 4",
                        Description = "Microsoft Surface Laptop 4 - 15\"",
                        Price = 1299.99m,
                        PictureFileName = "surface_laptop_4.jpg",
                        AvailableStock = 8,
                        ProductBrandId = microsoftId,
                        ProductTypeId = laptopId
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Sony BRAVIA XR A80J",
                        Description = "Sony BRAVIA XR A80J 65\" 4K OLED TV",
                        Price = 2499.99m,
                        PictureFileName = "sony_bravia_a80j.jpg",
                        AvailableStock = 12,
                        ProductBrandId = sonyId,
                        ProductTypeId = monitorId
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "LG Gram 17",
                        Description = "LG Gram 17 Ultra-Lightweight Laptop",
                        Price = 1499.99m,
                        PictureFileName = "lg_gram_17.jpg",
                        AvailableStock = 10,
                        ProductBrandId = lgId,
                        ProductTypeId = laptopId
                    },                    
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Samsung Odyssey G7",
                        Description = "Samsung Odyssey G7 27\" Curved Gaming Monitor",
                        Price = 699.99m,
                        PictureFileName = "samsung_odyssey_g7.jpg",
                        AvailableStock = 18,
                        ProductBrandId = samsungId,
                        ProductTypeId = monitorId
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Microsoft Surface Pro 8",
                        Description = "Microsoft Surface Pro 8 - 12.3\"",
                        Price = 1199.99m,
                        PictureFileName = "surface_pro_8.jpg",
                        AvailableStock = 15,
                        ProductBrandId = microsoftId,
                        ProductTypeId = tabletId
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Sony WH-1000XM4",
                        Description = "Sony WH-1000XM4 Wireless Noise-Canceling Headphones",
                        Price = 349.99m,
                        PictureFileName = "sony_wh_1000xm4.jpg",
                        AvailableStock = 25,
                        ProductBrandId = sonyId,
                        ProductTypeId = headphonesId
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "LG OLED48C1",
                        Description = "LG OLED48C1 48\" 4K OLED TV",
                        Price = 1499.99m,
                        PictureFileName = "lg_oled48c1.jpg",
                        AvailableStock = 10,
                        ProductBrandId = lgId,
                        ProductTypeId = monitorId
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Apple Watch Series 6",
                        Description = "Apple Watch Series 6 - GPS, 44mm",
                        Price = 399.99m,
                        PictureFileName = "apple_watch_series_6.jpg",
                        AvailableStock = 20,
                        ProductBrandId = appleId,
                        ProductTypeId = smartwatchId
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Samsung Odyssey G9",
                        Description = "Samsung Odyssey G9 49\" Curved Gaming Monitor",
                        Price = 1499.99m,
                        PictureFileName = "samsung_odyssey_g9.jpg",
                        AvailableStock = 8,
                        ProductBrandId = samsungId,
                        ProductTypeId = monitorId
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Microsoft Xbox Series X",
                        Description = "Microsoft Xbox Series X Console",
                        Price = 499.99m,
                        PictureFileName = "xbox_series_x.jpg",
                        AvailableStock = 12,
                        ProductBrandId = microsoftId,
                        ProductTypeId = videoGamesId
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Sony WF-1000XM4",
                        Description = "Sony WF-1000XM4 True Wireless Noise-Canceling Earbuds",
                        Price = 279.99m,
                        PictureFileName = "sony_wf_1000xm4.jpg",
                        AvailableStock = 15,
                        ProductBrandId = sonyId,
                        ProductTypeId = headphonesId
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "LG UltraWide 34WN80C-B",
                        Description = "LG UltraWide 34WN80C-B 34\" Curved Monitor",
                        Price = 549.99m,
                        PictureFileName = "lg_ultrawide_34wn80c.jpg",
                        AvailableStock = 20,
                        ProductBrandId = lgId,
                        ProductTypeId = monitorId
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Apple iPad Air (4th Gen)",
                        Description = "Apple iPad Air (4th Generation) - 10.9\"",
                        Price = 599.99m,
                        PictureFileName = "ipad_air_4th_gen.jpg",
                        AvailableStock = 18,
                        ProductBrandId = appleId,
                        ProductTypeId = tabletId
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Samsung Galaxy Watch 4",
                        Description = "Samsung Galaxy Watch 4 - Bluetooth, 44mm",
                        Price = 299.99m,
                        PictureFileName = "galaxy_watch_4.jpg",
                        AvailableStock = 25,
                        ProductBrandId = samsungId,
                        ProductTypeId = smartwatchId
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Microsoft Ergonomic Keyboard",
                        Description = "Microsoft Ergonomic Keyboard",
                        Price = 79.99m,
                        PictureFileName = "microsoft_ergonomic_keyboard.jpg",
                        AvailableStock = 30,
                        ProductBrandId = microsoftId,
                        ProductTypeId = keyboardId
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Sony X950H 65\" 4K TV",
                        Description = "Sony X950H 65\" 4K Ultra HD Smart LED TV",
                        Price = 1599.99m,
                        PictureFileName = "sony_x950h.jpg",
                        AvailableStock = 10,
                        ProductBrandId = sonyId,
                        ProductTypeId = monitorId
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "LG C1 OLED 55\" 4K TV",
                        Description = "LG OLED55C1PUB 55\" 4K OLED TV",
                        Price = 1699.99m,
                        PictureFileName = "lg_c1_oled.jpg",
                        AvailableStock = 8,
                        ProductBrandId = lgId,
                        ProductTypeId = monitorId
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Apple AirPods Pro",
                        Description = "Apple AirPods Pro - Active Noise Cancellation",
                        Price = 249.99m,
                        PictureFileName = "apple_airpods_pro.jpg",
                        AvailableStock = 20,
                        ProductBrandId = appleId,
                        ProductTypeId = headphonesId
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Samsung Odyssey G5",
                        Description = "Samsung Odyssey G5 27\" Curved Gaming Monitor",
                        Price = 349.99m,
                        PictureFileName = "samsung_odyssey_g5.jpg",
                        AvailableStock = 15,
                        ProductBrandId = samsungId,
                        ProductTypeId = monitorId
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Microsoft Surface Go 2",
                        Description = "Microsoft Surface Go 2 - 10.5\"",
                        Price = 399.99m,
                        PictureFileName = "surface_go_2.jpg",
                        AvailableStock = 12,
                        ProductBrandId = microsoftId,
                        ProductTypeId = tabletId
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Sony WH-XB900N",
                        Description = "Sony WH-XB900N Extra Bass Wireless Noise-Canceling Headphones",
                        Price = 199.99m,
                        PictureFileName = "sony_wh_xb900n.jpg",
                        AvailableStock = 18,
                        ProductBrandId = sonyId,
                        ProductTypeId = headphonesId
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "LG 27GL850-B",
                        Description = "LG 27GL850-B 27\" QHD Nano IPS Gaming Monitor",
                        Price = 499.99m,
                        PictureFileName = "lg_27gl850_b.jpg",
                        AvailableStock = 10,
                        ProductBrandId = lgId,
                        ProductTypeId = monitorId
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Apple iMac 24\"",
                        Description = "Apple iMac 24\" with M1 Chip",
                        Price = 1499.99m,
                        PictureFileName = "imac_24_inch.jpg",
                        AvailableStock = 8,
                        ProductBrandId = appleId,
                        ProductTypeId = monitorId
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Samsung Galaxy Buds Pro",
                        Description = "Samsung Galaxy Buds Pro True Wireless Earbuds",
                        Price = 199.99m,
                        PictureFileName = "galaxy_buds_pro.jpg",
                        AvailableStock = 15,
                        ProductBrandId = samsungId,
                        ProductTypeId = headphonesId
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Microsoft Surface Studio 2",
                        Description = "Microsoft Surface Studio 2 - 28\"",
                        Price = 3499.99m,
                        PictureFileName = "surface_studio_2.jpg",
                        AvailableStock = 5,
                        ProductBrandId = microsoftId,
                        ProductTypeId = monitorId
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Sony HT-Z9F Soundbar",
                        Description = "Sony HT-Z9F 3.1ch Dolby Atmos Soundbar",
                        Price = 899.99m,
                        PictureFileName = "sony_ht_z9f.jpg",
                        AvailableStock = 8,
                        ProductBrandId = sonyId,
                        ProductTypeId = audioSystemId
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "LG V60 ThinQ 5G",
                        Description = "LG V60 ThinQ 5G Smartphone",
                        Price = 899.99m,
                        PictureFileName = "lg_v60_thinq_5g.jpg",
                        AvailableStock = 10,
                        ProductBrandId = lgId,
                        ProductTypeId = smartphoneId
                    }
                };

                products.AddRange(productList);
                context.SaveChanges();
            }
        }

    }
}
