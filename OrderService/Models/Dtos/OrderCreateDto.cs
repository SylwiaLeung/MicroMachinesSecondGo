namespace OrderService.Models.Dtos
{
    public class OrderCreateDto
    {
        public IEnumerable<int> Products { get; set; }
        public int UserId { get; set; }
    }
}
