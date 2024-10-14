using Microsoft.EntityFrameworkCore;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation;

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

    public async Task<bool?> CheckContractIsActive(Guid id)
    {
        var contract = await _context.Contracts.FirstOrDefaultAsync(x => x.Id == id);
        if (contract is null)
            return null;
        var now = DateTime.Now;
        var isActive = now <= contract?.DateEnd && now >= contract?.DateStart;
        return isActive;
    }

    public async Task<Contract?> GetItem(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Contract[]> GetItems()
    {
        throw new NotImplementedException();
    }

    public async Task Update()
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<Contract>?> IRepository<Contract>.GetItems()
    {
        throw new NotImplementedException();
    }
}
