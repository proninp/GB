using HomeWork02.Domain.Models;

namespace HomeWork02.DataTransferObjects;

public class PersonDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Company { get; set; }
    public int Age { get; set; }
}

public static class PersonMappings
{
    public static PersonDto ToDto(this Person person)
    {
        return new PersonDto
        {
            FirstName = person.FirstName,
            LastName = person.LastName,
            Email = person.Email,
            Company = person.Company,
            Age = person.Age
        };
    }
}
