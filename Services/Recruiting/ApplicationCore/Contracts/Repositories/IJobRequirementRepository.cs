using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Repositories;

public interface IJobRequirementRepository
{
    List<JobRequirement> getAllJobRequirement();
    JobRequirement getJobRequirementByID(int id);
}