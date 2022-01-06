using Microsoft.EntityFrameworkCore;
using OrderService.Models;
using OrderService.Models.Dtos;

namespace OrderService.Data
{
    public static class PrepOrderDatabase
    {
        public static void Initialize()
        {
            var options = new DbContextOptionsBuilder<OrderDbContext>()
                .UseInMemoryDatabase(databaseName: "OrderDb")
                .Options;

            using (var context = new OrderDbContext(options))
            {
                if (!context.Orders.Any())
                {
                    context.Orders.AddRange(GetOrders());
                    context.SaveChanges();
                };
            }
        }

        private static IEnumerable<Order> GetOrders()
        {
            var stocks = new List<Order>()
            {
                new Order()
                {
                    Id = 1,
                    UserId = 1
                },
                new Order()
                { 
                    Id = 2, 
                    UserId = 2,
                    Products = new List<ProductReadDto>()
                    {
                        new ProductReadDto() { Id = 1, Name = "Test", Price = 10 },
                        new ProductReadDto() { Id = 2, Name = "Test2", Price = 20 }
                    },
                    Status = Status.Paid,
                    UpdatedDate = DateTime.Now
                }
            };
            return stocks;
        }
    }
}
