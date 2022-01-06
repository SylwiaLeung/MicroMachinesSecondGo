using MicroMachines.Models.Dtos;

namespace MicroMachines.HttpClients
{
    public interface IHttpOrdersClient
    {
        Task<IEnumerable<OrderReadDto>> GetUsersOrderHistoryAsync(int id);
        Task<IEnumerable<OrderReadDto>> GetUsersPurchaseHistoryAsync(int id);
        Task<OrderReadDto> CreateOrder(OrderCreateDto orderDto);
        Task<IEnumerable<OrderReadDto>> GetAllOrdersAsync();
        Task<OrderReadDto> PayForOrder(int orderId);
    }
}
