using System.ComponentModel.DataAnnotations;
using Shared.Models;

namespace UserService.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Funds { get; set; }
        public IEnumerable<ProductReadDto> Wishlist { get; set; }

    }
}
