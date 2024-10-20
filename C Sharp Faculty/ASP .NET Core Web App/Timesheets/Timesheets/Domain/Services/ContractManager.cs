using Microsoft.EntityFrameworkCore;
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

    public Task<Contract?> GetItem(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Contract>> GetItems()
    {
        throw new NotImplementedException();
    }

    public async Task<bool?> CheckContractIsActive(Guid id)
    {
        var contract = await _conractRepo.GetItem(id);
        if (contract is null)
            return null;
        var now = DateTime.Now;
        var isActive = now <= contract?.DateEnd && now >= contract?.DateStart;
        return isActive;
    }

    public Task<Guid> Create(ContractDto sheet)
    {
        throw new NotImplementedException();
    }

    public async Task<bool?> Update(Guid id, ContractDto contractDto)
    {
        var contract = await _conractRepo.GetItem(id);
        if (contract is null)
            return null;
        
        contract.Title = contractDto.Title;
        contract.Description = contractDto.Description;
        contract.DateStart = contractDto.DateStart;
        contract.DateEnd = contractDto.DateEnd;
        contract.IsDeleted = contractDto.IsDeleted;

        return await _conractRepo.Update(contract);
    }

    public async Task<bool?> Delete(Guid id)
    {
        var contract = await _conractRepo.GetItem(id);
        if (contract is null)
            return null;
        contract.IsDeleted = true;
        return await _conractRepo.Update(contract);
    }
}
