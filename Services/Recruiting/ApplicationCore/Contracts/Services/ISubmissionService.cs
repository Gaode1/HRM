using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface ISubmissionService
{
    List<Submission> getAllSubmission();

}