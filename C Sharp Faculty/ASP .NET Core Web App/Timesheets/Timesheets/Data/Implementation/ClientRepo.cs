using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation;

public class ClientRepo : IClientRepo
{
    public async Task Add(Client item)
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

    public async Task Update(Client item)
    {
        throw new NotImplementedException();
    }
}
