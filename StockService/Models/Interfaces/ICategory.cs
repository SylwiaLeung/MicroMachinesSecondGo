using StockService.Models.Entities;

namespace StockService.Models.Interfaces
{
    public interface ICategory
    {
        int Id { get; set; }
        string Name { get; set; }
        IEnumerable<Product> Products { get; set; }
    }
}
