using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Data.Repositories;

public class RepositoryInventoryRecord : IRepositoryInventoryRecord
{
    private readonly SqliteContext _context;

    public RepositoryInventoryRecord(SqliteContext context)
    {
        _context = context;
    }

    public async Task<InventoryRecord> GetByIdAsync(int id)
    {
        return await _context.InventoryRecords.FindAsync(id);
    }

    public async Task<IEnumerable<InventoryRecord>> GetAllAsync()
    {
        return await _context.InventoryRecords.ToListAsync();
    }

    public async Task<int> AddAsync(InventoryRecord entity)
    {
        _context.InventoryRecords.Add(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(InventoryRecord entity)
    {
        _context.InventoryRecords.Remove(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(InventoryRecord entity)
    {
        _context.InventoryRecords.Update(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<InventoryRecord> GetRecordOfProductInWarehouse(int pid, int wid)
    {
        var records = GetAllAsync().Result.ToList();
        foreach (var record in records)
        {
            if (record.ProductId == pid && record.WarehouseId == wid)
            {
                return record;
            }
        }

        return null;
    }
}