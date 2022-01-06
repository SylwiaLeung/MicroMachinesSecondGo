using StockService.Models.Interfaces;

namespace StockService.Models.Entities
{
    public class Category : ICategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Product>? Products { get; set; }
    }
}
