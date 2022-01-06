namespace StockService.Services
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetSingle(Func<T, bool> condition);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAllWithCondition(Func<T, bool> condition);
        Task Save();
    }
}
