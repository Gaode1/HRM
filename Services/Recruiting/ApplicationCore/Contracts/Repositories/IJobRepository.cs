using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Repositories;

public interface IJobRepository
{
    Task<List<Job>> GetAllJobs();
    Task<Job> GetJobById(int id);
}