using Timesheets.Models;

namespace Timesheets.Data.Interfaces;

public interface IContractRepo : IRepository<Contract>
{
    Task<bool> CheckContractIsActive(Guid id);
}
