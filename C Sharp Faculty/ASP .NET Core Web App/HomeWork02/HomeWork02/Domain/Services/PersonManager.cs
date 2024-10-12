using HomeWork02.Data.Interfaces;
using HomeWork02.DataTransferObjects;
using HomeWork02.Domain.Models;
using HomeWork02.Domain.Services.Abstractions;

namespace HomeWork02.Domain.Services;

public class PersonManager : IPersonManager
{
    private IPersonRepo _personRepo;

    public PersonManager(IPersonRepo personRepo)
    {
        _personRepo = personRepo;
    }

    public int Create(PersonDto personDto)
    {
        var newId = _personRepo.GetLast() + 1;
        var person = new Person
        {
            Id = newId,
            FirstName = personDto.FirstName,
            LastName = personDto.LastName,
            Email = personDto.Email,
            Company = personDto.Company,
            Age = personDto.Age
        };
        _personRepo.Add(person);
        return person.Id;
    }

    public bool Delete(int id)
    {
        var person = _personRepo.GetItem(id);
        if (person is null)
            return false;
        _personRepo.Delete(person);
        return true;
    }

    public PersonDto? GetPerson(int id)
    {
        var person = _personRepo.GetItem(id);
        return person?.ToDto();
    }

    public PersonDto? GetPerson(string searchTerm)
    {
        var person = _personRepo.GetItem(searchTerm);
        return person?.ToDto();
    }

    public IEnumerable<PersonDto>? GetPersons(int skip, int take)
    {
        var persons = _personRepo.GetItems(skip, take);
        return persons?.Select(p => p.ToDto());
    }

    public bool Update(int id, PersonDto personDto)
    {
        var person = _personRepo.GetItem(id);
        if (person is null)
            return false;

        person.FirstName = personDto.FirstName;
        person.LastName = personDto.LastName;
        person.Email = personDto.Email;
        person.Company = personDto.Company;
        person.Age = personDto.Age;

        return true;
    }
}
