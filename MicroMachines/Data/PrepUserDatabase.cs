using MicroMachines.Data;
using MicroMachines.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroMachines.Data
{
    public static class PrepUserDatabase
    {
        public static void Initialize()
        {
            var options = new DbContextOptionsBuilder<UserDbContext>()
                .UseInMemoryDatabase(databaseName: "UserDb")
                .Options;

            using (var context = new UserDbContext(options))
            {
                if (!context.Users.Any())
                {
                    context.Users.AddRange(GetUsers());
                    context.SaveChanges();
                }
            }
        }

        private static IEnumerable<User> GetUsers()
        {
            var users = new List<User>()
            {
                new User(){ Name = "Kot Lucek", Funds = 66.5M },
                new User(){ Name = "Kot Puotka", Funds = 132 },
                new User(){ Name = "Random", Funds = 1.69M }
            };
            return users;
        }
    }
}
