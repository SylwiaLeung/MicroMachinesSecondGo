using Microsoft.EntityFrameworkCore;
using StockService.Data;
using StockService.Models.Entities;
using StockService.Services.Interfaces;

namespace StockService.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly StockDbContext _context;

        public ProductRepository(StockDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products
                .Include(p => p.Stock)
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllWithCondition(Func<Product, bool> condition)
        {
            return await Task.Run(() => _context.Products
                .Include(p => p.Stock)
                .Include(p => p.Category)
                .Where(condition)
                .ToList());
        }

        public async Task<Product> GetSingle(int id)
        {
            return await _context.Products
                .Include(p => p.Stock)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
