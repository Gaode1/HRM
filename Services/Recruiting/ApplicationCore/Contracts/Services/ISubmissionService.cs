using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface ISubmissionService: IBaseService<Submission>
{
    Task<List<Submission>> GetSubmissionsByJobId(int id);

}