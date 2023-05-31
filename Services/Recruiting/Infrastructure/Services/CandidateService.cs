using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class CandidateService: BaseService<Candidate>,ICandidateService
{
    private readonly ICandidateRepository _candidateRepository;
    private readonly IBaseRepository<Candidate> _baseRepository;

    public CandidateService(ICandidateRepository candidateRepository, IBaseRepository<Candidate> baseRepository) : base(baseRepository)
    {
        _candidateRepository = candidateRepository;
        _baseRepository = baseRepository;
    }
    public List<Candidate> GetAllCandidates()
    {
        return _candidateRepository.GetAllCandidates();
    }
}