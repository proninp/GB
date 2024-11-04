using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Abstractions;

public interface ILoginManager
{
    Task<LoginResponse> Authenticate(User user);
}