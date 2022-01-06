namespace StockService.Models.Interfaces
{
    public interface IProduct
    {
        int Id { get; set; }
        string Name { get; set; }
        int CategoryId { get; set; }
        int StockId { get; set; }
        decimal Price { get; set; }
    }
}
