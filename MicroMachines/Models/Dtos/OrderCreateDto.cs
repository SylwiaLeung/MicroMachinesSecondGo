namespace MicroMachines.Models.Dtos
{
    public class OrderCreateDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
    }
}
