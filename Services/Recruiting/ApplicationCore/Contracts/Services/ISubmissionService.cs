using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface ISubmissionService
{
    List<SubmissionResponseModel> getAllSubmission();

}