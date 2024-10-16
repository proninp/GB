using Timesheets.Data.Abstractions;
using Timesheets.Models;

namespace Timesheets.Data.Repositories;

public class EmployeeRepo : IEmployeeRepo
{
    public async Task Add(Employee item)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Employee?> GetItem(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Employee>> GetItems()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Update(Employee item)
    {
        throw new NotImplementedException();
    }
}
