using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class SubmissionRepository: ISubmissionRepository
{
    private readonly RecruitingDbContext _dbContext;

    public SubmissionRepository(RecruitingDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<Submission>> getAllSubmission()
    {
        return await _dbContext.Submissions.ToListAsync();
    }
}