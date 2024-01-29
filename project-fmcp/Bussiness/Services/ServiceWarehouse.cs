using Data.Repositories;
using Shared.Models;

namespace Bussiness.Services;

public class ServiceWarehouse : IServiceWarehouse
{
    private readonly IRepositoryWarehouse _repository;

    public ServiceWarehouse(IRepositoryWarehouse repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Warehouse>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Warehouse> GetProductByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<int> AddProductAsync(Warehouse entity)
    {
        return await _repository.AddAsync(entity);
    }

    public async Task<int> UpdateProductAsync(Warehouse entity)
    {
        return await _repository.UpdateAsync(entity);
    }

    public async Task<int> DeleteProductAsync(int id)
    {
        var warehouse = await _repository.GetByIdAsync(id);
        return await _repository.DeleteAsync(warehouse);
    }
}