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

    public async Task Add(Contract item)
    {
        throw new NotImplementedException();
    }

    public async Task<Contract?> GetItem(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Contract>?> GetItems()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Update(Contract item)
    {
        throw new NotImplementedException();
    }

    public async Task<bool?> CheckContractIsActive(Guid id)
    {
        var contract = await _context.Contracts.FindAsync(id);
        if (contract is null)
            return null;
        var now = DateTime.Now;
        var isActive = now <= contract?.DateEnd && now >= contract?.DateStart;
        return isActive;
    }
}
