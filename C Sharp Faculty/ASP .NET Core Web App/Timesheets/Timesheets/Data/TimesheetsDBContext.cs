using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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
        modelBuilder.Entity<Client>().ToTable(nameof(Clients));
        modelBuilder.Entity<Contract>().ToTable(nameof(Contracts));
        modelBuilder.Entity<Employee>().ToTable(nameof(Employees));
        modelBuilder.Entity<Service>().ToTable(nameof(Services));
        modelBuilder.Entity<User>().ToTable(nameof(Users));

        modelBuilder.Entity<Sheet>().HasOne(sheet => sheet.Contract)
            .WithMany(contract => contract.Sheets)
            .HasForeignKey(nameof(Sheet.ContractId));

        modelBuilder.Entity<Sheet>().HasOne(sheet => sheet.Employee)
            .WithMany(employee => employee.Sheets)
            .HasForeignKey(nameof(Sheet.EmployeeId));

        modelBuilder.Entity<Sheet>().HasOne(sheet => sheet.Service)
            .WithMany(services => services.Sheets)
            .HasForeignKey(nameof(Sheet.ServiceId));
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(_options.Value.ConnectionString);
        }
    }
}
