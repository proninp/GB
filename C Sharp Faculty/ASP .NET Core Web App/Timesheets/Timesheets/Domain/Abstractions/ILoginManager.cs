using Timesheets.Models;

namespace Timesheets.Domain.Abstractions;

public interface ILoginManager
{
    Task<LoginResponse> Authenticate(User user);
}