using Shared.Models;

namespace UserService.Models
{
    public class UserUpdateDto
    {
        public decimal Funds { get; set; }
        public IEnumerable<ProductReadDto> Wishlist { get; set; }
    }
}
