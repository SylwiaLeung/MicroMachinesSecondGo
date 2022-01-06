using MicroMachines.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroMachines.Data
{
    public class UserDbContext: DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options): base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
