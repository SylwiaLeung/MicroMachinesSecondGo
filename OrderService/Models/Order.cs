using OrderService.Models.Dtos;

namespace OrderService.Models
{
    public class Order
    {
        public int Id { get; set; }
        public IEnumerable<ProductReadDto> Products { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; }
        public Status Status { get; set; } = Status.Created;

    }

    public enum Status { Created, Paid }
}
