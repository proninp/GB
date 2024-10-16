using Timesheets.Data.Abstractions;
using Timesheets.Models;

namespace Timesheets.Data.Repositories;

public class ServiceRepo : IServiceRepo
{
    public async Task Add(Service item)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Service?> GetItem(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Service>> GetItems()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Update(Service item)
    {
        throw new NotImplementedException();
    }
}
