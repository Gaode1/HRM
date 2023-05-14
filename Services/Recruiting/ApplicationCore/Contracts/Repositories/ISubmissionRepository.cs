using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Repositories;

public interface ISubmissionRepository
{
    List<SubmissionResponseModel> getAllSubmission();
}