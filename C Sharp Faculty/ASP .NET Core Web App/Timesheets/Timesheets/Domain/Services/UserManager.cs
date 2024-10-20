using Timesheets.Data.Abstractions;
using Timesheets.Domain.Abstractions;
using Timesheets.Models;
using Timesheets.Models.Dto;

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

    public async Task<Guid> Create(UserDto userDto)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = userDto.Username
        };
        await _userRepo.Add(user);
        return user.Id;
    }

    public async Task<bool?> Update(Guid id, UserDto userDto)
    {
        var user = await _userRepo.GetItem(id);
        if (user is null)
            return null;

        user.Username = userDto.Username;
        return await _userRepo.Update(user);
    }

    public async Task<bool?> Delete(Guid id)
    {
        var user = await _userRepo.GetItem(id);
        if (user is null)
            return null;

        return await _userRepo.Delete(id);
    }
}
