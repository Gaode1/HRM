using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CandidateRepository: ICandidateRepository
{
    private RecruitingDbContext _recruitingDbContext;

    public CandidateRepository(RecruitingDbContext recruitingDbContext)
    {
        _recruitingDbContext = recruitingDbContext;
    }

    public List<Candidate> GetAllCandidates()
    {
        var candidates = _recruitingDbContext.Candidates.ToList();
        return candidates;
    }
}