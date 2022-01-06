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
    }
}