using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface IJobRequirementService
{
    List<JobRequirement> getAllJobRequirement();
    JobRequirement getJobRequirementByID(int id);
}