using Microsoft.EntityFrameworkCore;
using StockService.Models.Entities;

namespace StockService.Data
{
    public static class PrepStockDatabase
    {
        public static void Initialize()
        {
            var options = new DbContextOptionsBuilder<StockDbContext>()
                .UseInMemoryDatabase(databaseName: "StockDb")
                .Options;

            using (var context = new StockDbContext(options))
            {
                if (!context.Stocks.Any())
                {
                    context.Stocks.AddRange(GetStocks());
                    context.SaveChanges();
                }
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(GetCategories());
                    context.SaveChanges();
                }
                if (!context.Products.Any())
                {
                    context.Products.AddRange(GetProducts());
                    context.SaveChanges();
                }
                if (!context.ProductCounts.Any())
                {
                    context.ProductCounts.AddRange(GetProductCounts());
                    context.SaveChanges();
                }
            }
        }

        private static IEnumerable<Stock> GetStocks()
        {
            var stocks = new List<Stock>()
            {
                new Stock(){ Id = 1, Name = "Człowiekowy magazyn" },
                new Stock(){ Id = 2, Name = "Koci magazyn" }                
            };
            return stocks;
        }

        private static IEnumerable<Category> GetCategories()
        {
            var categories = new List<Category>()
            {
                new Category(){ Id = 1, Name = "Zabawki" },
                new Category(){ Id = 2, Name = "Jedzonko" },
                new Category(){ Id = 3, Name = "Spanie" },
            };
            return categories;
        }

        private static IEnumerable<Product> GetProducts()
        {
            var products = new List<Product>()
            {
                new Product(){ Id = 1, Name = "Wędka", StockId = 2, CategoryId = 1, Price = 2.55M },
                new Product(){ Id = 2, Name = "Karma w puszce", StockId = 2, CategoryId = 2, Price = 8.85M },
                new Product(){ Id = 3, Name = "Karton", StockId = 2, CategoryId = 3, Price = 10.00M },
                new Product(){ Id = 4, Name = "Banan", StockId = 1, CategoryId = 2, Price = 1.50M },
                new Product(){ Id = 5, Name = "Futon", StockId = 1, CategoryId = 3, Price = 398.00M },
                new Product(){ Id = 6, Name = "Pompon", StockId = 2, CategoryId = 1, Price = 0.90M },
            };
            return products;
        }

        private static IEnumerable<ProductCount> GetProductCounts()
        {
            var productcounts = new List<ProductCount>()
            {
                new ProductCount(){ ProductId = 1, StockId = 2, Quantity = 10 },
                new ProductCount(){ ProductId = 2, StockId = 2, Quantity = 50 },
                new ProductCount(){ ProductId = 3, StockId = 2, Quantity = 2 },
                new ProductCount(){ ProductId = 4, StockId = 1, Quantity = 5 },
                new ProductCount(){ ProductId = 5, StockId = 1, Quantity = 1 },
                new ProductCount(){ ProductId = 6, StockId = 2, Quantity = 20 },
            };
            return productcounts;
        }
    }
}