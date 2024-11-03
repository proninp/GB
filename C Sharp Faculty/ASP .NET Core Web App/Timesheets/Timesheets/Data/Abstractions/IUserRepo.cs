using Timesheets.Models;

namespace Timesheets.Data.Abstractions;

public interface IUserRepo : IRepository<User>
{
    Task<User?> GetByLoginAndPasswordHash(string login, byte[] passwordHash);
}
