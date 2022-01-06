using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderService.Models;
using OrderService.Models.Dtos;
using OrderService.Services;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepo;
        // readonly IHttpProductsClient _client;

        public OrdersController(IMapper mapper, IOrderRepository orderRepo)
        {
            _mapper = mapper;
            _orderRepo = orderRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderReadDto>>> GetAllOrdersHistory()
        {
            var orders = await _orderRepo.GetAll();

            return Ok(_mapper.Map<List<OrderReadDto>>(orders));
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<OrderReadDto>>> GetUsersOrderHistory(int userId)
        {
            var orders = await _orderRepo.GetAllByCondition(o => o.UserId == userId);

            return Ok(_mapper.Map<List<OrderReadDto>>(orders));
        }

        [HttpGet("purchases/{userId}")]
        public async Task<ActionResult<IEnumerable<OrderReadDto>>> GetUsersPurchaseHistory(int userId)
        {
            var orders = await _orderRepo.GetAllByCondition(o => o.UserId == userId && o.Status == Status.Paid);

            return Ok(_mapper.Map<List<OrderReadDto>>(orders));
        }

        [HttpPost]
        public async Task<bool> CreateOrder(OrderCreateDto order)
        {
            var products = order.Products;
            var orderEntity = _mapper.Map<Order>(order);
            await _orderRepo.Create(orderEntity);
            await _orderRepo.Save();

            return true;
        }

    }
}