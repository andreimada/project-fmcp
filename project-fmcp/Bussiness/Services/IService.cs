namespace Bussiness.Services {
    public interface IService<T> where T : class {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetProductByIdAsync(int id);
        Task<int> AddProductAsync(T entity);
        Task<int> UpdateProductAsync(T entity);
        Task<int> DeleteProductAsync(int id);
    }
}
