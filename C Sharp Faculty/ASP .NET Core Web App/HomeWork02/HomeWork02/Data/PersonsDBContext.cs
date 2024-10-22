using HomeWork02.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork02.Data;

public class PersonsDBContext : DbContext
{
    public PersonsDBContext(DbContextOptions<PersonsDBContext> options) : base(options)
    {

    }

    public DbSet<Person> Persons { get; set; }
}
