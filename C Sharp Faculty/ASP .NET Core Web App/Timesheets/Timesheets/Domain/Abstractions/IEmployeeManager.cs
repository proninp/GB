using Timesheets.Models.Dto;
using Timesheets.Models;

namespace Timesheets.Domain.Abstractions;

public interface IEmployeeManager : IManager<Employee, Guid, EmployeeDto, EmployeeDto>
{
    Task<IEnumerable<Employee>> GetActiveEmployees();
}
