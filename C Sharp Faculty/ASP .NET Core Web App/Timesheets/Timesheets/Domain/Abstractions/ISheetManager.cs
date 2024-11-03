using Timesheets.Domain.Abstractions;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.InterAbstractionsfaces;

public interface ISheetManager : IManager<Sheet, Guid, SheetDto, SheetDto>
{
}