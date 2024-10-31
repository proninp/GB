using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Timesheets.Data.Configurations;
using Timesheets.Models;
using Timesheets.Options;

namespace Timesheets.Data;

public class TimesheetsDBContext : DbContext
{
    private readonly IOptions<DbOptions> _options;

    public TimesheetsDBContext(IOptions<DbOptions> options)
    {
        _options = options;
    }

    public DbSet<Client> Clients { get; set; }

    public DbSet<Contract> Contracts { get; set; }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<Service> Services { get; set; }

    public DbSet<Sheet> Sheets { get; set; }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClientConfiguration(nameof(Clients)));
        modelBuilder.ApplyConfiguration(new ContractConfiguration(nameof(Contracts)));
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration(nameof(Employees)));
        modelBuilder.ApplyConfiguration(new ServiceConfiguration(nameof(Services)));
        modelBuilder.ApplyConfiguration(new UserConfiguration(nameof(Users)));
        modelBuilder.ApplyConfiguration(new SheetConfiguration(nameof(Sheets)));
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(_options.Value.ConnectionString);
        }
    }
}
