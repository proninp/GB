using Microsoft.EntityFrameworkCore;
using Timesheets.Data.Abstractions;
using Timesheets.Models;

namespace Timesheets.Data.Repositories;

public class ContractRepo : IContractRepo
{
    private readonly TimesheetsDBContext _context;

    public ContractRepo(TimesheetsDBContext context)
    {
        _context = context;
    }

    public async Task<Contract?> GetItem(Guid id)
    {
        return await _context
            .Contracts
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IEnumerable<Contract>?> GetItems()
    {
        return await _context
            .Contracts
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task Add(Contract item)
    {
        _context.Add(item);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> Update(Contract item)
    {
        _context.Contracts.Update(item);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> Delete(Guid id)
    {
        var result = await _context.Contracts.Where(c => c.Id == id).ExecuteDeleteAsync();
        return result > 0;
    }
}
