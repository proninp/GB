using HomeWork02.DataTransferObjects;

namespace HomeWork02.Domain.Services.Abstractions;

public interface IPersonManager
{
    Task<PersonDto?> GetPerson(Guid id);

    Task<PersonDto?> GetPerson(string searchTerm);

    Task<IEnumerable<PersonDto>?> GetPersons(int skip, int take);

    Task<Guid> Create(PersonDto person);

    Task<bool?> Update(Guid id, PersonDto person);

    Task<bool?> Delete(Guid id);
}