namespace StockService.Services
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetSingle(int id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAllWithCondition(Func<T, bool> condition);
        Task Save();
    }
}
