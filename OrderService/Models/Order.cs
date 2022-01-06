namespace OrderService.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Status Status { get; set; }
        public decimal Amount { get; set; }

    }

    public enum Status { Created, Paid }
}
