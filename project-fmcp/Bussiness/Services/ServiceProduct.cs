using System.Runtime.CompilerServices;
using Data.Repositories;
using Shared.Models;

namespace Bussiness.Services;

public class ServiceProduct : IServiceProduct
{
    private readonly IRepositoryProduct _repository;

    public ServiceProduct(IRepositoryProduct repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<int> AddProductAsync(Product entity)
    {
        return await _repository.AddAsync(entity);
    }

    public async Task<int> UpdateProductAsync(Product entity)
    {
        return await _repository.UpdateAsync(entity);
    }

    public async Task<int> DeleteProductAsync(int id)
    {
        var product = await _repository.GetByIdAsync(id);
        return await _repository.DeleteAsync(product);
    }
}