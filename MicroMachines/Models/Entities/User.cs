using System.ComponentModel.DataAnnotations;

namespace MicroMachines.Entities
{
    public class User : IUser
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Funds { get; set; }
    }
}
