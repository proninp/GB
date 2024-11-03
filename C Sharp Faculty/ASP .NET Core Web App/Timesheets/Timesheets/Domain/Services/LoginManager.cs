using Timesheets.Domain.Abstractions;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Services;

public class LoginManager : ILoginManager
{
    public Task<LoginResponse> Authenticate(User user)
    {
        throw new NotImplementedException();
    }
}
