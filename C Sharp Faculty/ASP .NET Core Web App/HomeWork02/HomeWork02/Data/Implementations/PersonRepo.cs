using HomeWork02.Data.Interfaces;
using HomeWork02.Domain.Models;

namespace HomeWork02.Data.Implementations;

public class PersonRepo : IPersonRepo
{
    private List<Person> _persons;

    public PersonRepo(List<Person> persons)
    {
        _persons = persons;
    }

    public void Add(Person item)
    {
        _persons.Add(item);
    }

    public void Delete(Person item)
    {
        _persons.Remove(item);
    }

    public Person? GetItem(int id)
    {
        return _persons.FirstOrDefault(p => p.Id == id);
    }

    public Person? GetItem(string searchTerm)
    {
        return _persons.FirstOrDefault(p => p.FirstName.ToLower().Contains(searchTerm.ToLower()));
    }

    public IEnumerable<Person> GetItems(int skip, int take) =>
        _persons.Skip(skip).Take(take);

    public int GetLast() =>
        _persons.Last()?.Id ?? 0;
}
