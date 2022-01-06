using StockService.Models.Interfaces;

namespace StockService.Models.Entities
{
    public class Product : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StockId { get; set; }
        public Stock? Stock { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public decimal Price { get; set; }

    }
}
