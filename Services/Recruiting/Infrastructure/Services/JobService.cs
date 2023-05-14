using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class JobService : IJobService
{
    public List<JobResponseModel> GetAllJobs()
    {
        var jobs = new List<JobResponseModel>()
        {
            new JobResponseModel(){Id = 1, Description = ".NET", Title = "Senior .Net Developer"},
            new JobResponseModel(){Id = 2, Description = "Java", Title = "Senior Java Developer"}
        };
        return jobs;
    }

    public JobResponseModel GetJobById(int id)
    {
        throw new NotImplementedException();
    }
}