using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockService.Models.Dtos;
using StockService.Models.Dtos.Product;
using StockService.Models.Entities;
using StockService.Services;
using StockService.Services.Interfaces;

namespace StockService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StocksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepo;
        private readonly IStockRepository _stockRepo;


        public StocksController(IMapper mapper, IProductRepository productRepo, IStockRepository stockRepo)
        {
            _mapper = mapper;
            _productRepo = productRepo;
            _stockRepo = stockRepo;
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

        //[HttpGet("{id}")]
        //public async Task<ActionResult<ProductCountReadDto>> OrderProduct(int id, [FromQuery] int qty)
        //{
        //    var product = _productRepo.GetSingle(p => p.Id == id);
        //    var stockId = product.StockId;

        //    var productCount = _stockRepo
        //        .GetSingle(s => s.Id == stockId)
        //        .Products
        //        .FirstOrDefault(p => p.ProductId == id);

        //    if (productCount == null) return NotFound();

        //    if (productCount.Quantity >= qty)
        //    {
        //        var result = await MakeOrder(productCount, qty, product);
        //        return Ok(result);
        //    }
        //    return BadRequest();
        //}

        //private async Task<ProductCountReadDto> MakeOrder(ProductCount productCount, int qty, Product product)
        //{
        //    productCount.Quantity -= qty;
        //    await _productRepo.Save();
        //    var productRead = _mapper.Map<ProductCountReadDto>(productCount);
        //    productRead.Quantity = qty;
        //    productRead.Amount = product.Price * qty;

        //    return productRead;
        //}
    }
}