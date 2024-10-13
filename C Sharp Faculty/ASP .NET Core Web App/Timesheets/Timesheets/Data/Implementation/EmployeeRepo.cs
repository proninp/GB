using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation;

public class EmployeeRepo : IEmployeeRepo
{
    public async Task Add(Employee item)
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

    public async Task Update()
    {
        throw new NotImplementedException();
    }
}
