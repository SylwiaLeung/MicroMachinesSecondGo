using Shared.Models;

namespace MicroMachines.HttpClients
{
    public interface IHttpUserClient
    {
        Task<UserReadDto> GetSingle(int userId);
    }
}
