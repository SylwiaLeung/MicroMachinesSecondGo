namespace OrderService.Models.Dtos
{
    public class OrderReadDto
    {
        public int Id { get; set; }
        public IEnumerable<ProductReadDto> Products { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Status Status { get; set; }
    }
}
