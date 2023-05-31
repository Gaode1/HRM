using System.Linq.Expressions;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;

namespace Infrastructure.Services;

public class BaseService<T>: IBaseService<T> where T : class
{
    protected readonly IBaseRepository<T> BaseRepository;

    public BaseService(IBaseRepository<T> baseRepository)
    {
        BaseRepository = baseRepository;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await BaseRepository.GetAllAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await BaseRepository.GetByIdAsync(id);
    }

    public async Task<bool> GetExistsAsync()
    {
        return await BaseRepository.GetExistsAsync();
    }

    public async Task<T> AddTAsync(T entity)
    {
        return await BaseRepository.AddTAsync(entity);
    }

    public async Task<T> UpdateTAsync(T entity)
    {
        return await BaseRepository.UpdateTAsync(entity);
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await BaseRepository.DeleteAsync(id);
    }
}