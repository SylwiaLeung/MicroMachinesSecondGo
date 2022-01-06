using MicroMachines.Models.Dtos;

namespace MicroMachines
{
    public interface IHttpStockClient
    {
        Task<IEnumerable<ProductReadDto>> GetAllProductsAsync();
        Task<IEnumerable<ProductReadDto>> GetProductsByCategoryAsync(string categoryName);
        Task<ProductReadDto> GetProductById(int productId);
    }
}
