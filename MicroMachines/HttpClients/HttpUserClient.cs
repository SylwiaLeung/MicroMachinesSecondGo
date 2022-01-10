using MicroMachines.Models.Dtos;

namespace MicroMachines.HttpClients
{
    public class HttpUserClient : IHttpUserClient
    {
        public Task<UserReadDto> GetSingle(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
