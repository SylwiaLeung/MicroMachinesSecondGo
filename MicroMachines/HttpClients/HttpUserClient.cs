using Shared.Models;
using System.Net.Http.Formatting;

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

        public async Task<UserReadDto> AddFunds(int userId, decimal amount)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Put, $"{_url}/api/users/{userId}?amount={amount}");
            var response = await _httpClient.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<UserReadDto>(new[] { new JsonMediaTypeFormatter() });
            }
            else
            {
                return null;
            }
        }

        public async Task<UserReadDto> GetSingle(int userId)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{_url}/api/users/{userId}");
            var response = await _httpClient.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<UserReadDto>(new[] { new JsonMediaTypeFormatter() });
            }
            else
            {
                return null;
            }
        }
    }
}
