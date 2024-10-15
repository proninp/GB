using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation;

public class ServiceRepo : IServiceRepo
{
    public async Task Add(Service item)
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

    public async Task Update(Service item)
    {
        throw new NotImplementedException();
    }
}
