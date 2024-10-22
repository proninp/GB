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

    public async Task<PersonDto?> GetPerson(Guid id)
    {
        var person = await _personRepo.GetItem(id);
        return person?.ToDto();
    }

    public async Task<PersonDto?> GetPerson(string searchTerm)
    {
        var person = await _personRepo.GetItem(searchTerm);
        return person?.ToDto();
    }

    public async Task<IEnumerable<PersonDto>?> GetPersons(int skip, int take)
    {
        var persons = await _personRepo.GetItems(skip, take);
        return persons?.Select(person => person.ToDto());
    }

    public async Task<Guid> Create(PersonDto personDto)
    {
        var person = new Person
        {
            Id = Guid.NewGuid(),
            FirstName = personDto.FirstName,
            LastName = personDto.LastName,
            Email = personDto.Email,
            Company = personDto.Company,
            Age = personDto.Age
        };
        await _personRepo.Add(person);
        return person.Id;
    }

    public async Task<bool?> Update(Guid id, PersonDto personDto)
    {
        var person = new Person
        {
            Id = id,
            FirstName = personDto.FirstName,
            LastName = personDto.LastName,
            Email = personDto.Email,
            Company = personDto.Company,
            Age = personDto.Age
        };
        return await _personRepo.Update(person);
    }

    public async Task<bool?> Delete(Guid id)
    {
        if (await _personRepo.GetItem(id) is null)
            return null;
        return await _personRepo.Delete(id);
    }
}