using Microsoft.EntityFrameworkCore;
using Timesheets.Data.Abstractions;
using Timesheets.Models;

namespace Timesheets.Data.Repositories;

public class EmployeeRepo : IEmployeeRepo
{
    private readonly TimesheetsDBContext _context;

    public EmployeeRepo(TimesheetsDBContext context)
    {
        _context = context;
    }

    public async Task<Employee?> GetItem(Guid id)
    {
        return await _context
            .Employees
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IEnumerable<Employee>> GetItems()
    {
        return await _context
            .Employees
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Employee>> GetActiveEmployees()
    {
        IQueryable<Employee> employees =
            _context
            .Employees
            .Where(e => e.IsDeleted == false)
            .AsNoTracking();

        return await employees.ToListAsync();
    }

    public async Task Add(Employee item)
    {
        _context.Add(item);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> Update(Employee item)
    {
        _context.Employees.Update(item);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> Delete(Guid id)
    {
        var employee = await _context
            .Employees
            .FirstOrDefaultAsync(e => e.Id == id);
        if (employee is null)
            return false;

        employee.IsDeleted = true;
        return await _context.SaveChangesAsync() > 0;
    }
}
