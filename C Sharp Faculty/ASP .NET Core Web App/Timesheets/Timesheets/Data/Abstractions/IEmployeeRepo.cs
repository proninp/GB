using Timesheets.Models;

namespace Timesheets.Data.Abstractions;

public interface IEmployeeRepo : IRepository<Employee>
{
    Task<IEnumerable<Employee>> GetActiveEmployees();
}
