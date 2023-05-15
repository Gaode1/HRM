using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Repositories;

public class JobRequirementRepository: IJobRequirementRepository
{
    public List<JobRequirement> getAllJobRequirement()
    {
        throw new NotImplementedException();
    }

    public JobRequirement getJobRequirementByID(int id)
    {
        throw new NotImplementedException();
    }
}