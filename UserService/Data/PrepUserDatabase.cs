using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace UserService.Data
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
                new User(){ Id = 1, Name = "Kot Lucek", Funds = 66.5M },
                new User(){ Id = 2, Name = "Kot Puotka", Funds = 132 },
                new User(){ Id = 3, Name = "Random", Funds = 1.69M }
            };
            return users;
        }
    }
}
