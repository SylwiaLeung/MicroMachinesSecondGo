namespace MicroMachines.Services
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetSingle(int id);
        Task Add(T entity);
        void Edit(T entity);
        void Delete(T entity);
        Task Save();
    }
}
