
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Interfaces;

public interface ISheetManager
{
    Task<Sheet?> GetItem(Guid id);

    Task<IEnumerable<Sheet>> GetItems();

    Task<Guid> Create(SheetDto sheet);

    Task Update(Guid id, SheetDto sheetDto);
}
