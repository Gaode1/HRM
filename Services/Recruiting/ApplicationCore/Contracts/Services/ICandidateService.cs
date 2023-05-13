using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface ICandidateService
{
    List<CandidateResponseModel> GetAllCandidates();
}