using Timesheets.Domain.Abstractions;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Services;

public class EmployeeManager : IEmployeeManager
{
    public Task<Employee?> GetItem(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Employee>?> GetItems()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Employee>> GetActiveEmployees()
    {
        throw new NotImplementedException();
    }

    public Task<Guid> Create(EmployeeDto item)
    {
        throw new NotImplementedException();
    }

    public Task<bool?> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool?> Update(Guid id, EmployeeDto itemDto)
    {
        throw new NotImplementedException();
    }
}
