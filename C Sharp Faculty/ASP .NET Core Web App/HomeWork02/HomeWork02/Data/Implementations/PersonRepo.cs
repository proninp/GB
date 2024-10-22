using HomeWork02.Data.Interfaces;
using HomeWork02.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork02.Data.Implementations;

public class PersonRepo : IPersonRepo
{
    private readonly PersonsDBContext _context;

    public PersonRepo(PersonsDBContext context)
    {
        _context = context;
    }

    public async Task Add(Person item)
    {
        await _context.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task<Person?> GetItem(Guid id)
    {
        return await _context.Persons.FindAsync(id);
    }

    public async Task<Person?> GetItem(string searchTerm)
    {
        return await _context.Persons
            .FirstOrDefaultAsync(p => p.FirstName.ToLower()
            .Contains(searchTerm.ToLower()));
    }

    public async Task<IEnumerable<Person>?> GetItems(int skip, int take)
    {
        return await _context.Persons
            .Skip(skip).Take(take)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<bool?> Update(Person item)
    {
        var person = await _context.Persons.FindAsync(item.Id);
        if (person is null)
            return null;

        person.FirstName = item.FirstName;
        person.LastName = item.LastName;
        person.Email = item.Email;
        person.Company = item.Company;
        person.Age = item.Age;

        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> Delete(Guid id)
    {
        var result = await _context.Persons.Where(p => p.Id == id).ExecuteDeleteAsync();
        return result > 0;
    }
}
