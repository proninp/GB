namespace Timesheets.Models.Dto;

public class CreateUserDto
{
    public string UserName { get; set; }

    public string Password { get; set; }

    public string Role { get; set; }
}
