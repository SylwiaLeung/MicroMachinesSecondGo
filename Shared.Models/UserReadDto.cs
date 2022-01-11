namespace Shared.Models
{
    public class UserReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Funds { get; set; }
        public IEnumerable<int> Wishlist { get; set; }
    }
}
