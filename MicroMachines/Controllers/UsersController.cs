using AutoMapper;
using MicroMachines.HttpClients;
using MicroMachines.Models.Dtos;
using MicroMachines.Services;
using Microsoft.AspNetCore.Mvc;

namespace MicroMachines.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IHttpOrdersClient _ordersClient;
        private readonly IHttpStockClient _stockClient;

        public UsersController(IHttpOrdersClient ordersClient, IHttpStockClient stockClient)
        {
            _ordersClient = ordersClient;
            _stockClient = stockClient;
        }

        [HttpGet("orders")]
        public async Task<ActionResult<IEnumerable<OrderReadDto>>> GetUsersOrderHistory()
        {
            var orders = await _ordersClient.GetAllOrdersAsync();
            if (orders == null) return BadRequest();
            return Ok(orders);
        }

        [HttpGet("orders/{userId}")]
        public async Task<ActionResult<IEnumerable<OrderReadDto>>> GetUsersOrderHistory(int userId)
        {
            var orders = await _ordersClient.GetUsersOrderHistoryAsync(userId);
            if (orders == null) return BadRequest();
            return Ok(orders);
        }

        [HttpGet("purchases/{userId}")]
        public async Task<ActionResult<IEnumerable<OrderReadDto>>> GetUsersPurchaseHistory(int userId)
        {
            var orders = await _ordersClient.GetUsersPurchaseHistoryAsync(userId);
            return Ok(orders);
        }
                  
        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<ProductReadDto>>> BrowseProducts()
        {
            var products = await _stockClient.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("products/{categoryName}")]
        public async Task<ActionResult<IEnumerable<ProductReadDto>>> BrowseProductsByCategory(string categoryName)
        {
            var products = await _stockClient.GetProductsByCategoryAsync(categoryName);
            return Ok(products);
        }

        [HttpPost("orders")]
        public async Task<ActionResult> CreateNewOrder([FromBody] OrderCreateDto orderDto)
        {
            var succeeded = await _ordersClient.CreateOrder(orderDto);
            return succeeded ? NoContent() : BadRequest();
        }

        //[HttpPut("{orderId}")]
        //public async Task PayForOrder(int orderId)
        //{

        //}
    }
}
