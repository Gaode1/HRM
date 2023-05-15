using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Repositories;

public interface ISubmissionRepository
{
    List<Submission> getAllSubmission();
}