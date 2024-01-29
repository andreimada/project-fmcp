﻿using System.Linq.Expressions;

namespace Data.Repositories {
    public interface IRepository<T> where T : class {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<int> AddAsync(T entity);
        Task<int> DeleteAsync(T entity);
        Task<int> UpdateAsync(T entity);
    }
}
