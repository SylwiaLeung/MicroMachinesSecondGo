using Shared.Models;

namespace MicroMachines.HttpClients
{
    public class HttpUserClient : IHttpUserClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _url = "http://UserService:80";

        public HttpUserClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<UserReadDto> GetSingle(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
