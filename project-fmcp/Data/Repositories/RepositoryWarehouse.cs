using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Data.Repositories;

public class RepositoryWarehouse : IRepositoryWarehouse
{
    private readonly SqliteContext _context;

    public RepositoryWarehouse(SqliteContext context)
    {
        _context = context;
    }

    public async Task<Warehouse> GetByIdAsync(int id)
    {
        return await _context.Warehouses.FindAsync(id);
    }

    public async Task<IEnumerable<Warehouse>> GetAllAsync()
    {
        return await _context.Warehouses.ToListAsync();
    }

    public async Task<int> AddAsync(Warehouse entity)
    {
        _context.Warehouses.Add(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(Warehouse entity)
    {
        _context.Warehouses.Remove(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(Warehouse entity)
    {
        _context.Warehouses.Update(entity);
        return await _context.SaveChangesAsync();
    }
}