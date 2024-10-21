using Timesheets.Data.Abstractions;
using Timesheets.Domain.Abstractions;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Services;

public class EmployeeManager : IEmployeeManager
{
    private readonly IEmployeeRepo _employeeRepo;

    public EmployeeManager(IEmployeeRepo employeeRepo)
    {
        _employeeRepo = employeeRepo;
    }

    public Task<Employee?> GetItem(Guid id)
    {
        return _employeeRepo.GetItem(id);
    }

    public Task<IEnumerable<Employee>?> GetItems()
    {
        return _employeeRepo.GetItems();
    }

    public Task<IEnumerable<Employee>> GetActiveEmployees()
    {
        return _employeeRepo.GetActiveEmployees();
    }

    public async Task<Guid> Create(EmployeeDto employeeDto)
    {
        var employee = new Employee()
        {
            Id = Guid.NewGuid(),
            UserId = employeeDto.UserId,
            IsDeleted = employeeDto.IsDeleted
        };
        await _employeeRepo.Add(employee);
        return employee.Id;
    }

    public async Task<bool?> Update(Guid id, EmployeeDto employeeDto)
    {
        var employee = await _employeeRepo.GetItem(id);
        if (employee is null)
            return null;

        employee.UserId = employeeDto.UserId;
        employee.IsDeleted = employeeDto.IsDeleted;

        return await _employeeRepo.Update(employee);
    }

    public async Task<bool?> Delete(Guid id)
    {
        var employee = await _employeeRepo.GetItem(id);
        if (employee is null)
            return null;
        employee.IsDeleted = true;
        return await _employeeRepo.Update(employee);
    }
}
