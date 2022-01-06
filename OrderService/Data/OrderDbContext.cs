using Microsoft.EntityFrameworkCore;
using OrderService.Models;
using OrderService.Models.Dtos;

namespace OrderService.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
    }
}
