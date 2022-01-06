namespace StockService.Models.Entities
{
    public class Stock
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Product>? Products { get; set; }
    }
}
