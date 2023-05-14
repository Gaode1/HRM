using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Repositories;

public interface IEmployeeRepository
{
    List<EmployeeResponseModel> GetALlEmployee();
}