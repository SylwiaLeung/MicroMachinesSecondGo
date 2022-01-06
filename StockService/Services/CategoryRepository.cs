using Microsoft.EntityFrameworkCore;
using StockService.Data;
using StockService.Models.Entities;
using StockService.Services.Interfaces;

namespace StockService.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StockDbContext _context;

        public CategoryRepository(StockDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories
                .Include(x => x.Products)
                .ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetAllWithCondition(Func<Category, bool> condition)
        {
            return await Task.Run(() =>_context.Categories
                .Include(x => x.Products)
                .Where(condition)
                .ToList());
        }

        public async Task<Category> GetSingle(int id)
        {
            return await Task.Run(() => _context.Categories
                .Include(x => x.Products)
                .FirstOrDefault(c => c.Id == id));
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
