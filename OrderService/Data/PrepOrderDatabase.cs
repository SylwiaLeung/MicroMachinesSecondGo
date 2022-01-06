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
                    ProductName = "Ananas",
                    Amount = 10,
                    UserId = 1
                },
                new Order()
                { 
                    Id = 2, 
                    UserId = 2,
                    ProductName = "Kwiatek",
                    Amount = 100,
                    Status = Status.Paid,
                    UpdatedDate = DateTime.Now
                }
            };
            return stocks;
        }
    }
}
