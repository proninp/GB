using Timesheets.Models.Dto;
using Timesheets.Models;

namespace Timesheets.Domain.Abstractions;

public interface IContractManager : IManager<Contract, Guid, ContractDto>
{
    Task<bool?> CheckContractIsActive(Guid id);
}
