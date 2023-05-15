using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Repositories;

public interface ISubmissionRepository
{
    Task<List<Submission>> getAllSubmission();
}