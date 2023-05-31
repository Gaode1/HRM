using System.Linq.Expressions;
using ApplicationCore.Contracts.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BaseRepository<T>: IBaseRepository<T> where T : class
{
    protected readonly RecruitingDbContext RecruitingDbContext;

    public BaseRepository(RecruitingDbContext recruitingDbContext)
    {
        RecruitingDbContext = recruitingDbContext;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await RecruitingDbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await RecruitingDbContext.Set<T>().FindAsync(id);
    }

    public async Task<bool> GetExistsAsync(Expression<Func<T, bool>>? filter = null)
    {
        if (filter == null)
        {
            return false;
        }
        //LinQ
        //employees.where(e=>e.salary>10000).any()  ---------this way better
        //employees.where(e=>e.salary>10000).count()>1
        return await RecruitingDbContext.Set<T>().Where(filter).AnyAsync();
    }

    public async Task<T> AddTAsync(T entity)
    {
        RecruitingDbContext.Set<T>().Add(entity);
        await RecruitingDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<T> UpdateTAsync(T entity)
    {
        RecruitingDbContext.Set<T>().Update(entity);
        await RecruitingDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<int> DeleteAsync(int id)
    {   
        RecruitingDbContext.Set<T>().Remove(await GetByIdAsync(id));
        await RecruitingDbContext.SaveChangesAsync();
        return id;
    }
}