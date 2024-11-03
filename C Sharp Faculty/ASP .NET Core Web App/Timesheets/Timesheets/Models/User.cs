namespace Timesheets.Models;

public class User
{
    public Guid Id { get; set; }
    
    public string UserName { get; set; }

    public byte[] PasswordHash { get; set; }

    public string Role { get; set; }
}
