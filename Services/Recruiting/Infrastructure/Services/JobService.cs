using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Infrastructure.Services;

public class JobService : IJobService
{
    private readonly IJobRepository _jobRepository;

    public JobService(IJobRepository jobRepository)
    {
        _jobRepository = jobRepository;
    }
    public List<JobResponseModel> GetAllJobs()
    {
        var jobs = _jobRepository.GetAllJobs();
            // This code can be done by using LinQ:
            // foreach(var job in jobs)
            // {
            //     jobResponseModels.Add(new JobResponseModel()
            //     {
            //         Id = job.Id, Description = job.Description, Title = job.Title
            //     });
            // }
        return jobs.Select(job => new JobResponseModel() { Id = job.Id, Description = job.Description, Title = job.Title }).ToList();
    }

    public JobResponseModel GetJobById(int id)
    {
        var job = _jobRepository.GetJobById(id);
        return new JobResponseModel() { Id = job.Id, Description = job.Description, Title = job.Title };
    }
}