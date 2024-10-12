using HomeWork02.Domain.Models;

namespace HomeWork02.Data.Interfaces;

public interface IPersonRepo : IRepository<Person>
{
    Person? GetItem(string searchTerm);

    int GetLast();
}
