using Timesheets.Models.Dto;
using Timesheets.Models;

namespace Timesheets.Domain.Interfaces;

public interface IContractManager
{
    Task<Sheet?> GetItem(Guid id);

    Task<IEnumerable<Sheet>> GetItems();

    Task<Guid> Create(SheetCreateRequest sheet);

    Task<bool> CheckContractIsActive(Guid id);
}
