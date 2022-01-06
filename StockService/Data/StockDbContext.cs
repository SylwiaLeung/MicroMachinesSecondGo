using Microsoft.EntityFrameworkCore;
using StockService.Models.Entities;

namespace StockService.Data
{
    public class StockDbContext : DbContext
    {
        public StockDbContext(DbContextOptions<StockDbContext> options) : base(options)
        {

        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Product> Products { get;set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCount> ProductCounts { get; set; }
    }
}
