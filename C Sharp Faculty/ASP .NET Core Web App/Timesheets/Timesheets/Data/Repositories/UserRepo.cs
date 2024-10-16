using Timesheets.Data.Abstractions;
using Timesheets.Models;

namespace Timesheets.Data.Repositories;

public class UserRepo : IUserRepo
{
    private readonly TimesheetsDBContext _context;

    public UserRepo(TimesheetsDBContext context)
    {
        _context = context;
    }

    public async Task Add(User item)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetItem(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<User>> GetItems()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Update(User item)
    {
        throw new NotImplementedException();
    }
}
