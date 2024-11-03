using Timesheets.Models.Dto;
using Timesheets.Models;

namespace Timesheets.Domain.Abstractions;

public interface IUserManager : IManager<User, Guid, UserDto, CreateUserDto>
{
    Task<User?> GetUser(LoginRequest request);
}
