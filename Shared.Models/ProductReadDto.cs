namespace Shared.Models
{
    public class ProductReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string StockName { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }
    }
}
