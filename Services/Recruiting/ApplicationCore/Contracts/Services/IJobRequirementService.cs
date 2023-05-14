using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface IJobRequirementService
{
    List<JobRequirementResponseModel> getAllJobRequirement();
    JobRequirementResponseModel getJobRequirementByID(int id);
}