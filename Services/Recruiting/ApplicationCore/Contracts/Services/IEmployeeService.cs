using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface IEmployeeService
{
    List<EmployeeResponseModel> GetALlEmployee();

}