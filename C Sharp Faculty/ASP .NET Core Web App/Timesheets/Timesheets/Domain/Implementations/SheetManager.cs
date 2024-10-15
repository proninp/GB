using Timesheets.Data.Interfaces;
using Timesheets.Domain.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Implementations;

public class SheetManager : ISheetManager
{
    private readonly ISheetRepo _sheetRepo;

    public SheetManager(ISheetRepo sheetRepo)
    {
        _sheetRepo = sheetRepo;
    }

    public async Task<Guid> Create(SheetDto sheetDto)
    {
        var sheet = new Sheet
        {
            Id = Guid.NewGuid(),
            Date = sheetDto.Date,
            ContractId = sheetDto.ContractId,
            EmployeeId = sheetDto.EmployeeId,
            ServiceId = sheetDto.ServiceId,
            Amount = sheetDto.Amount
        };
        await _sheetRepo.Add(sheet);
        return sheet.Id;
    }

    public async Task<Sheet?> GetItem(Guid id)
    {
        return await _sheetRepo.GetItem(id);
    }

    public async Task<IEnumerable<Sheet>?> GetItems()
    {
        return await _sheetRepo.GetItems();
    }

    public async Task Update(Guid id, SheetDto sheetDto)
    {
        var sheet = new Sheet
        {
            Id = id,
            Date = sheetDto.Date,
            ContractId = sheetDto.ContractId,
            EmployeeId = sheetDto.EmployeeId,
            ServiceId = sheetDto.ServiceId,
            Amount = sheetDto.Amount
        };
        await _sheetRepo.Update(sheet);
    }
}
