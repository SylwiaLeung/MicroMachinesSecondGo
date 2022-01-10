using MicroMachines.Models.Dtos;

namespace MicroMachines.HttpClients
{
    public interface IHttpUserClient
    {
        Task<UserReadDto> GetSingle(int userId);
    }
}
