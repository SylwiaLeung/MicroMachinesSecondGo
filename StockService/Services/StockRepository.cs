using Microsoft.EntityFrameworkCore;
using StockService.Data;
using StockService.Models.Entities;

namespace StockService.Services
{
    public class StockRepository : IStockRepository
    {
        private readonly StockDbContext _context;

        public StockRepository(StockDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Stock>> GetAll()
        {
            return await _context.Stocks.ToListAsync();
        }

        public async Task<IEnumerable<Stock>> GetAllWithCondition(Func<Stock, bool> condition)
        {
            return await Task.Run(() => _context.Stocks.Where(condition));
        }

        public async Task<Stock> GetSingle(int id)
        {
            return await Task.Run(() => _context
                .Stocks
                .Include(s => s.Products)
                .FirstOrDefault(s => s.Id == id));
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
