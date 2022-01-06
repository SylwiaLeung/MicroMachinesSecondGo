using MicroMachines.Models.Dtos;

namespace MicroMachines.HttpClients
{
    public interface IHttpOrdersClient
    {
        Task<IEnumerable<OrderReadDto>> GetUsersOrderHistoryAsync(int id);
        Task<IEnumerable<OrderReadDto>> GetUsersPurchaseHistoryAsync(int id);
        Task<bool> CreateOrder(OrderCreateDto orderDto);
        Task<IEnumerable<OrderReadDto>> GetAllOrdersAsync();
    }
}
