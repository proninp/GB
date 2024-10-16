using Timesheets.Models;

namespace Timesheets.Data.Abstractions;

public interface IContractRepo : IRepository<Contract>
{
    Task<bool?> CheckContractIsActive(Guid id);
}
