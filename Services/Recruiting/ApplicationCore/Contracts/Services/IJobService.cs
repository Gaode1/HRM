using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface IJobService:IBaseService<Job>
{
    Task<List<JobResponseModel>> GetAllJobs();
    Task<JobResponseModel> GetJobById(int id);

    Task<int> AddJob(JobRequestModel model);
    Task<int> UpdateJob(JobRequestModel model);
    Task<int> DeleteJob(int id);
}