using Timesheets.Data.Abstractions;
using Timesheets.Domain.Abstractions;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Services;

public class ContractManager : IContractManager
{
    private IContractRepo _conractRepo;

    public ContractManager(IContractRepo conractRepo)
    {
        _conractRepo = conractRepo;
    }

    public async Task<bool?> CheckContractIsActive(Guid id)
    {
        return await _conractRepo.CheckContractIsActive(id);
    }

    public Task<Guid> Create(SheetDto sheet)
    {
        throw new NotImplementedException();
    }

    public Task<Sheet?> GetItem(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Sheet>> GetItems()
    {
        throw new NotImplementedException();
    }
}
