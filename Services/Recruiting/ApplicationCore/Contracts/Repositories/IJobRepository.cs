using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Repositories;

public interface IJobRepository
{
    List<JobResponseModel> GetAllJobs();
    JobResponseModel GetJobById(int id);
}