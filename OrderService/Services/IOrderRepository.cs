using OrderService.Models;

namespace OrderService.Services
{
    public interface IOrderRepository
    {
        Task Save();
        Task Create(Order order);
        Task<IEnumerable<Order>> GetAllByCondition(Func<Order, bool> condition);
        Task<IEnumerable<Order>> GetAll();
    }
}
