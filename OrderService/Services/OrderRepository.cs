using Microsoft.EntityFrameworkCore;
using OrderService.Data;
using OrderService.Models;

namespace OrderService.Services
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _context;

        public OrderRepository(OrderDbContext context)
        {
            _context = context;
        }

        public async Task Create(Order order)
        {
            await _context.AddAsync(order);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAllByCondition(Func<Order, bool> condition)
        {
            return await Task.Run(() => _context.Orders.Include(x => x.Products).Where(condition));
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await Task.Run(() => _context.Orders.Include(x => x.Products));
        }
    }
}
