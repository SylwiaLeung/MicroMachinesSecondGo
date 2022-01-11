using Shared.Models;
using System.Net.Http.Formatting;

namespace MicroMachines.HttpClients
{
    public class HttpStockClient : IHttpStockClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _url = "http://StockService:80";

        public HttpStockClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductReadDto>> GetProductsByCategoryAsync(string categoryName)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{_url}/api/stocks/category/{categoryName}");
            var response = await _httpClient.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<List<ProductReadDto>>(new[] { new JsonMediaTypeFormatter() });
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<ProductReadDto>> GetAllProductsAsync()
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{_url}/api/stocks");
            var response = await _httpClient.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<List<ProductReadDto>>(new[] { new JsonMediaTypeFormatter() });
            }
            else
            {
                return null;
            }
        }

        public async Task<ProductReadDto> GetProductById(int productId)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{_url}/api/stocks/{productId}");
            var response = await _httpClient.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<ProductReadDto>(new[] { new JsonMediaTypeFormatter() });
            }
            else
            {
                return null;
            }
        }
    }
}
