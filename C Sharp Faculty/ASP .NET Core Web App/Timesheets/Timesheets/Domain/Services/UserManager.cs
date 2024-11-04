using Timesheets.Data.Abstractions;
using Timesheets.Domain.Abstractions;
using Timesheets.Models;
using Timesheets.Models.Dto;
using System.Security.Cryptography;
using System.Text;
using Timesheets.Infrastructure.Extensions;

namespace Timesheets.Domain.Services;

public class UserManager : IUserManager
{
    private readonly IUserRepo _userRepo;

    public UserManager(IUserRepo userRepo)
    {
        _userRepo = userRepo;
    }

    public async Task<User?> GetItem(Guid id)
    {
        return await _userRepo.GetItem(id);
    }

    public async Task<IEnumerable<User>?> GetItems()
    {
        return await _userRepo.GetItems();
    }

    public async Task<User?> GetUser(LoginRequest request)
    {
        var passwordHash = GetPasswordHash(request.Password);
        var user = await _userRepo.GetByLoginAndPasswordHash(request.Login, passwordHash);
        return user;
    }

    public async Task<Guid> Create(CreateUserDto userRequestDto)
    {
        userRequestDto.EnsureNotNull(nameof(userRequestDto));

        var user = new User
        { 
            Id = Guid.NewGuid(),
            UserName = userRequestDto.UserName,
            PasswordHash = GetPasswordHash(userRequestDto.Password),
            Role = userRequestDto.Role
        };

        await _userRepo.Add(user);
        return user.Id;
    }

    public async Task<bool?> Update(Guid id, UserDto userDto)
    {
        var user = await _userRepo.GetItem(id);
        if (user is null)
            return null;

        user.UserName = userDto.UserName;
        return await _userRepo.Update(user);
    }

    public async Task<bool?> Delete(Guid id)
    {
        var user = await _userRepo.GetItem(id);
        if (user is null)
            return null;

        return await _userRepo.Delete(id);
    }

    private byte[] GetPasswordHash(string password)
    {
        using var sha1 = new SHA1CryptoServiceProvider();
        return sha1.ComputeHash(Encoding.Unicode.GetBytes(password));
    }
}
