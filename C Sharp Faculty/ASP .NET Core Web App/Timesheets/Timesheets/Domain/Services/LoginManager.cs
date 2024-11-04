using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Timesheets.Domain.Abstractions;
using Timesheets.Infrastructure.Extensions;
using Timesheets.Models;
using Timesheets.Models.Dto;
using Timesheets.Models.Dto.Auth;

namespace Timesheets.Domain.Services;

public class LoginManager : ILoginManager
{
    private readonly JwtAccessOptions _jwtAccessOptions;

    public LoginManager(IOptions<JwtAccessOptions> jwtAccessOptions)
    {
        _jwtAccessOptions = jwtAccessOptions.Value;
    }

    public async Task<LoginResponse> Authenticate(User user)
    {
        var claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
            new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
        };

        var accessTokenRaw = _jwtAccessOptions.GenerateToken(claims);
        var secutityHandler = new JwtSecurityTokenHandler();

        var accessToken = secutityHandler.WriteToken(accessTokenRaw);

        var loginResponse = new LoginResponse()
        {
            AccessToken = accessToken,
            ExpiresIn = accessTokenRaw.ValidTo.ToEpochTime(),
        };

        return loginResponse;
    }
}
