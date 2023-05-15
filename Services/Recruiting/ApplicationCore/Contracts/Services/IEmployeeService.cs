using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface IEmployeeService
{
    List<Employee> GetALlEmployee();

}