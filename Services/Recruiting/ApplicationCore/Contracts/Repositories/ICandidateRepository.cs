using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Repositories;

public interface ICandidateRepository
{
    List<Candidate> GetAllCandidates();
}