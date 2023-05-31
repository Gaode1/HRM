using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class SubmissionService: BaseService<Submission>, ISubmissionService
{
    private readonly ISubmissionRepository _submissionRepository;
    private readonly IBaseRepository<Submission> _baseRepository;

    public SubmissionService(ISubmissionRepository submissionRepository, IBaseRepository<Submission> baseRepository) : base(baseRepository)
    {
        _submissionRepository = submissionRepository;
        _baseRepository = baseRepository;
    }

    public async Task<List<Submission>> GetSubmissionsByJobId(int id)
    {
        return await _submissionRepository.GetSubmissionsByJobId(id);
    }
}