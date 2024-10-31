using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timesheets.Models;

namespace Timesheets.Data.Configurations;
public class SheetConfiguration(string tableName) : IEntityTypeConfiguration<Sheet>
{
    public void Configure(EntityTypeBuilder<Sheet> builder)
    {
        builder.ToTable(tableName);

        builder.HasOne(sheet => sheet.Contract)
            .WithMany(contract => contract.Sheets)
            .HasForeignKey(nameof(Sheet.ContractId));

        builder.HasOne(sheet => sheet.Employee)
            .WithMany(employee => employee.Sheets)
            .HasForeignKey(nameof(Sheet.EmployeeId));

        builder.HasOne(sheet => sheet.Service)
            .WithMany(services => services.Sheets)
            .HasForeignKey(nameof(Sheet.ServiceId));
    }
}