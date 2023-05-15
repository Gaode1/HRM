using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class SubmissionRepository: ISubmissionRepository
{
    private readonly RecruitingDbContext _dbContext;

    public SubmissionRepository(RecruitingDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public List<Submission> getAllSubmission()
    {
        return _dbContext.Submissions.ToList();
    }
}