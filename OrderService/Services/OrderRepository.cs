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

        public async Task Update(Order order)
        {
            await Task.Run(() => _context.Orders.Update(order));
        }

        public async Task<IEnumerable<Order>> GetAllByCondition(Func<Order, bool> condition)
        {
            return await Task.Run(() => _context.Orders.Where(condition));
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await Task.Run(() => _context.Orders);
        }

        public async Task<Order> GetSingle(int orderId)
        {
            return await _context.Orders
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }
    }
}
