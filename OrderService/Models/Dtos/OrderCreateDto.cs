namespace OrderService.Models.Dtos
{
    public class OrderCreateDto
    {
        public string ProductName { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public Status Status { get; set; } = Status.Created;
    }
}
