using Microsoft.EntityFrameworkCore;
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

    public async Task<User?> GetItem(Guid id)
    {
        return await _context
            .Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<IEnumerable<User>?> GetItems()
    {
        return await _context
            .Users
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task Add(User item)
    {
        _context.Add(item);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> Update(User item)
    {
        _context.Users.Update(item);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> Delete(Guid id)
    {
        var result = await _context.Users.Where(u => u.Id == id).ExecuteDeleteAsync();
        return result > 0;
    }
}
