using ApplicationCore.Contract.Repositories;

namespace Infrastructure.Repositories;

public class BaseRepository<T>:IBaseRepository<T> where T : class
{
    public Task<IEnumerable<T>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<T> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<T> AddItem(T item)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteItem(int id)
    {
        throw new NotImplementedException();
    }
}