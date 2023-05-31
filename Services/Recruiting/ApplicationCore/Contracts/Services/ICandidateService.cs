using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface ICandidateService : IBaseService<Candidate>
{
    List<Candidate> GetAllCandidates();
}