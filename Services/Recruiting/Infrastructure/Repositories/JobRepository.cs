using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Models;

namespace Infrastructure.Repositories;

public class JobRepository : IJobRepository
{
    public List<JobResponseModel> GetAllJobs()
    {
        throw new NotImplementedException();
    }

    public JobResponseModel GetJobById(int id)
    {
        throw new NotImplementedException();
    }
}