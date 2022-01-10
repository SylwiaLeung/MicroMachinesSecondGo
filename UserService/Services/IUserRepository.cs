using UserService.Models;

namespace UserService.Services
{
    public interface IUserRepository
    {
        Task<User> GetSingle(int id);
        Task Save();
    }
}
