using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Models;

namespace Infrastructure.Repositories;

public class JobRequirementRepository: IJobRequirementRepository
{
    public List<JobRequirementResponseModel> getAllJobRequirement()
    {
        throw new NotImplementedException();
    }

    public JobRequirementResponseModel getJobRequirementByID(int id)
    {
        throw new NotImplementedException();
    }
}