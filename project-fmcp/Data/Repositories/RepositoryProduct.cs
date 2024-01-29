using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Data.Repositories;

public class RepositoryProduct : IRepositoryProduct
{
    private readonly SqliteContext _context;

    public RepositoryProduct(SqliteContext context)
    {
        _context = context;
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<int> AddAsync(Product entity)
    {
        _context.Products.Add(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(Product entity)
    {
        _context.Products.Remove(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(Product entity)
    {
        _context.Products.Update(entity);
        return await _context.SaveChangesAsync();
    }
}