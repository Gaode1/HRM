using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class SubmissionService: ISubmissionService
{
    private readonly ISubmissionRepository _submissionRepository;

    public SubmissionService(ISubmissionRepository submissionRepository)
    {
        _submissionRepository = submissionRepository;
    }
    public List<Submission> getAllSubmission()
    {
        return _submissionRepository.getAllSubmission();
    }
}