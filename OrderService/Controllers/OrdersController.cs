using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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

        [HttpGet("id/{orderId}")]
        public async Task<ActionResult<OrderReadDto>> GetOrderById(int orderId)
        {
            var order = await _orderRepo.GetSingle(orderId);

            return Ok(_mapper.Map<OrderReadDto>(order));
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
        public async Task<ActionResult<OrderReadDto>> CreateOrder(OrderCreateDto order)
        {
            var orderEntity = _mapper.Map<Order>(order);
            await _orderRepo.Create(orderEntity);
            await _orderRepo.Save();

            return Ok(_mapper.Map<OrderReadDto>(orderEntity));
        }

        [HttpPut("{orderId}")]
        public async Task<ActionResult<OrderReadDto>> PayForOrder(int orderId)
        {
            var order = await _orderRepo.GetSingle(orderId);

            order.Status = Status.Paid;
            await _orderRepo.Save();

            return Ok(_mapper.Map<OrderReadDto>(order));
        }
    }
}