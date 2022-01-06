using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockService.Models.Dtos;
using StockService.Services.Interfaces;

namespace StockService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StocksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepo;


        public StocksController(IMapper mapper, IProductRepository productRepo)
        {
            _mapper = mapper;
            _productRepo = productRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetAllProducts()
        {
            var productEntities = await _productRepo.GetAll();

            return Ok(_mapper.Map<List<ProductReadDto>>(productEntities));
        }

        [HttpGet("category/{categoryName}")]
        public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetAllProductsFromCategory(string categoryName)
        {
            var productEntities = await _productRepo.GetAllWithCondition(u => u.Category.Name == categoryName);

            if (!productEntities.Any())
                return NotFound();

            return Ok(_mapper.Map<List<ProductReadDto>>(productEntities));
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<ProductReadDto>> GetProductById(int productId)
        {
            var productEntity = await _productRepo.GetSingle(productId);

            if (productEntity == null)
                return NotFound();

            return Ok(_mapper.Map<ProductReadDto>(productEntity));
        }
    }
}