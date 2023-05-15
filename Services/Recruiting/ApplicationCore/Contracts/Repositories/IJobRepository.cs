using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Repositories;

public interface IJobRepository
{
    List<Job> GetAllJobs();
    Job GetJobById(int id);
}