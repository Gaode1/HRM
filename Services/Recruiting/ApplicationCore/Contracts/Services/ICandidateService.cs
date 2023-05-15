using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface ICandidateService
{
    List<Candidate> GetAllCandidates();
}