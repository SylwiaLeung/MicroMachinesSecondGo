namespace MicroMachines.Services
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetSingle(int id);
    }
}
