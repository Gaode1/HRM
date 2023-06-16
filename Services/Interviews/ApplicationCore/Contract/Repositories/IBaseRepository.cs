namespace ApplicationCore.Contract.Repositories;

public interface IBaseRepository<T> where T :class
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(int id);
    Task<T> AddItem(T item);
    Task<int> DeleteItem(int id);
}