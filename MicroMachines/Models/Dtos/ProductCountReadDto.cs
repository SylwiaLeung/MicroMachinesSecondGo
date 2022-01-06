namespace MicroMachines.Models.Dtos
{
    public class ProductCountReadDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
    }
}