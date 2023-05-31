using System.Linq.Expressions;

namespace ApplicationCore.Contracts.Services;

public interface IBaseService<T> where T:class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<bool> GetExistsAsync();
    Task<T> AddTAsync(T entity);
    Task<T> UpdateTAsync(T entity);
    Task<int> DeleteAsync(int id);
}