using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Models;

namespace Infrastructure.Repositories;

public class CandidateRepository: ICandidateRepository
{
    public List<CandidateResponseModel> GetAllCandidates()
    {
        throw new NotImplementedException();
    }
}