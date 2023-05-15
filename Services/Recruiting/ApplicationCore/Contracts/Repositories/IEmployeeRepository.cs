using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Repositories;

public interface IEmployeeRepository
{
    List<Employee> GetALlEmployee();
}