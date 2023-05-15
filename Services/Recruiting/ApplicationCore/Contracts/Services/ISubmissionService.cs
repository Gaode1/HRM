using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface ISubmissionService
{
    Task<List<Submission>> getAllSubmission();

}