using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Repositories;

public interface IJobRequirementRepository
{
    List<JobRequirementResponseModel> getAllJobRequirement();
    JobRequirementResponseModel getJobRequirementByID(int id);
}