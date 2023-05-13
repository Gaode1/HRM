using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Repositories;

public interface ICandidateRepository
{
    List<CandidateResponseModel> GetAllCandidates();
}