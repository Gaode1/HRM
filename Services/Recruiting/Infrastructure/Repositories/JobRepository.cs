using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class JobRepository : IJobRepository
{
    private RecruitingDbContext _recruitingDbContext;

    public JobRepository(RecruitingDbContext recruitingDbContext)
    {
        _recruitingDbContext = recruitingDbContext;
    }

    public List<Job> GetAllJobs()
    {
        var jobs = _recruitingDbContext.Jobs.ToList();
        return jobs;
    }

    public Job GetJobById(int id) 
    {
        var job = _recruitingDbContext.Jobs.FirstOrDefault(j => j.Id == id, new Job());
        return job;
    }
}