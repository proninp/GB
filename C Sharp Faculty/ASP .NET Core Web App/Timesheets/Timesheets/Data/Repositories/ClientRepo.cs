using Timesheets.Data.Abstractions;
using Timesheets.Models;

namespace Timesheets.Data.Repositories;

public class ClientRepo : IClientRepo
{
    public async Task Add(Client item)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Client?> GetItem(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Client>> GetItems()
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(Client item)
    {
        throw new NotImplementedException();
    }
}
