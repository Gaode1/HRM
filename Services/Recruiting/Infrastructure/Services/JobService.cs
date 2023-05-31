using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Infrastructure.Services;

public class JobService : BaseService<Job>, IJobService
{
    private readonly IJobRepository _jobRepository;
    private readonly IBaseRepository<Job> _baseRepository;

    public JobService(IJobRepository jobRepository, IBaseRepository<Job> baseRepository) : base(baseRepository)
    {
        _jobRepository = jobRepository;
        _baseRepository = baseRepository;
    }
    public async Task<List<JobResponseModel>> GetAllJobs()
    {
        var jobs =  await _jobRepository.GetAllJobs();
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

    public async Task<JobResponseModel> GetJobById(int id)
    {
        var job = await _jobRepository.GetJobById(id);
        if (job == null) return null;
        return new JobResponseModel() { Id = job.Id, Description = job.Description, Title = job.Title };
    }

    public async Task<int> AddJob(JobRequestModel model)
    {
        //call the repository and use EF core to save data
        var jobEntity = new Job()
        {
            Title = model.Title, Description = model.Description, JobCode = Guid.NewGuid(),
            CreatedOn = DateTime.UtcNow, NumberOfPositions = model.NumOfPositions, StartDate = model.StartDate, StatusId = 1
        };
        var job = await _jobRepository.AddTAsync(jobEntity);
        return job.Id;
    }

    public async Task<int> UpdateJob(JobRequestModel model)
    {
        var jobEntity = new Job()
        {
            Id = model.Id, Title = model.Title, Description = model.Description,
            NumberOfPositions = model.NumOfPositions, StartDate = model.StartDate, StatusId = 1, JobCode = Guid.NewGuid()
        };
        var job = await _jobRepository.UpdateTAsync(jobEntity);
        return job.Id;
    }

    public async Task<int> DeleteJob(int id)
    {
        await _jobRepository.DeleteAsync(id);
        return id;
    }
}