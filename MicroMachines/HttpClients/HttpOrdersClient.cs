using Shared.Models;
using System.Net.Http.Formatting;

namespace MicroMachines.HttpClients
{
    public class HttpOrdersClient : IHttpOrdersClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _url = "http://OrderService:80";

        public HttpOrdersClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<OrderReadDto> CreateOrder(OrderCreateDto orderDto)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_url}/api/orders", orderDto);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<OrderReadDto>(new[] { new JsonMediaTypeFormatter() });
        }

        public async Task<IEnumerable<OrderReadDto>> GetAllOrdersAsync()
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{_url}/api/orders");
            var response = await _httpClient.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<List<OrderReadDto>>(new[] { new JsonMediaTypeFormatter() });
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<OrderReadDto>> GetUsersOrderHistoryAsync(int userId)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{_url}/api/orders/{userId}");
            var response = await _httpClient.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<List<OrderReadDto>>(new[] { new JsonMediaTypeFormatter() });
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<OrderReadDto>> GetUsersPurchaseHistoryAsync(int userId)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{_url}/api/orders/purchases/{userId}");
            var response = await _httpClient.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<List<OrderReadDto>>(new[] { new JsonMediaTypeFormatter() });
            }
            else
            {
                return null;
            }
        }

        public async Task<OrderReadDto> PayForOrder(int orderId)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Put, $"{_url}/api/orders/{orderId}");
            var response = await _httpClient.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<OrderReadDto>(new[] { new JsonMediaTypeFormatter() });
            }
            else
            {
                return null;
            }
        }
    }
}
