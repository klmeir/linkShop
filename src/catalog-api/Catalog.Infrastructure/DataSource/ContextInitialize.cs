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
                        PictureFileName = "https://mac-center.com/cdn/shop/files/MacBook_Pro_13_in_Space_Gray_PDP_Image_Position-1_MXLA_5395ce92-3d36-4483-a995-b6bb011179c0.jpg",
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
                        PictureFileName = "https://mac-center.com/cdn/shop/files/MacBook_Pro_13_in_Space_Gray_PDP_Image_Position-2_MXLA_8b6fbfd9-029c-4818-83b2-20eb8565280c.jpg",
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
                        PictureFileName = "https://i.blogs.es/76a009/02_galaxybudslive_tabs7plus_lifestyle_image/1366_2000.jpg",
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
                        PictureFileName = "https://techcommunity.microsoft.com/t5/image/serverpage/image-id/272481i3CADA8AE37DE4503/image-size/large",
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
                        PictureFileName = "https://www.muycomputer.com/wp-content/uploads/2021/04/Sony-BRAVIA-XR-A80J-OLED-4K-Precio-e1618300208825.jpg",
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
                        PictureFileName = "https://m.media-amazon.com/images/I/71Wbbw-Nd4L.__AC_SX300_SY300_QL70_FMwebp_.jpg",
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
                        PictureFileName = "https://http2.mlstatic.com/D_NQ_NP_852704-MCO48829482076_012022-O.webp",
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
                        PictureFileName = "https://assets-prd.ignimgs.com/2021/10/16/dsc01038-1634342416340.JPG?crop=16%3A9&width=888",
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
                        PictureFileName = "https://i.blogs.es/7af9e0/sony-wh-1000xm4-analisis/1366_2000.jpg",
                        AvailableStock = 25,
                        ProductBrandId = sonyId,
                        ProductTypeId = headphonesId
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Apple Watch Series 6",
                        Description = "Apple Watch Series 6 - GPS, 44mm",
                        Price = 399.99m,
                        PictureFileName = "https://quieromac.com/cdn/shop/files/AppleWatchSerie6Azul_1.jpg",
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
                        PictureFileName = "https://img.global.news.samsung.com/latin/wp-content/uploads/2020/06/Odyssey-G9_4.jpg",
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
                        PictureFileName = "https://i.blogs.es/27a10a/captura-de-pantalla-2024-06-09-a-las-20.22.51/1200_800.png",
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
                        PictureFileName = "https://fdn.gsmarena.com/imgroot/news/22/02/wf-1000xm4-long-term/inline/-1200w5/gsmarena_001.jpg",
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
                        PictureFileName = "https://www.lg.com/content/dam/channel/wcms/co/images/monitores/34wn80c-b_awp_escb_co_c/450.jpg",
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
                        PictureFileName = "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/refurb-ipad-air-wifi-gold-2021",
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
                        PictureFileName = "https://img.global.news.samsung.com/co/wp-content/uploads/2021/11/Samsung_galaxywatch4_green_pinkgold_galaxywatch4classic_black_silver_H.png",
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
                        PictureFileName = "https://m.media-amazon.com/images/I/61HQHgyE6+L._AC_SY300_SX300_.jpg",
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
                        PictureFileName = "https://m.media-amazon.com/images/I/61RtiEExjrL.__AC_SY300_SX300_QL70_FMwebp_.jpg",
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
                        PictureFileName = "https://www.lg.com/content/dam/channel/wcms/co/images/televisores/oled55c1psa_awc_escb_co_c/md07525899-450x450.jpg",
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
                        PictureFileName = "https://www.apple.com/newsroom/images/product/airpods/standard/Apple-AirPods-Pro-2nd-gen-hero-220907_big.jpg.large.jpg",
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
                        PictureFileName = "https://virtualmuebles.com/cdn/shop/products/61XDeaOrrKL._AC_SL1000.jpg",
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
                        PictureFileName = "https://http2.mlstatic.com/D_NQ_NP_734928-MCO53984924367_022023-O.webp",
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
                        PictureFileName = "https://www.sony.es/image/a7a7277a3ac2458d64b30546a9ff3392",
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
                        PictureFileName = "https://m.media-amazon.com/images/I/81ZYbkU1uKL.jpg",
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
                        PictureFileName = "https://mundomac.com.ec/wp-content/uploads/2021/11/iMac_24-azul.jpg",
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
                        PictureFileName = "https://img.global.news.samsung.com/pe/wp-content/uploads/2021/01/buds-pro.jpg",
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
                        PictureFileName = "https://images-cdn.ubuy.co.in/651c3fd774f53a1c6c7ac265-microsoft-surface-laptop-studio-2-2023.jpg",
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
                        PictureFileName = "https://i.rtings.com/assets/products/XYCVey24/sony-ht-z9f/design-medium.jpg",
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
                        PictureFileName = "https://images-cdn.ubuy.com.sa/633b91b7eef0737d9568d2b7-used-lg-v60-thinq-5g-verizon-only.jpg",
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
