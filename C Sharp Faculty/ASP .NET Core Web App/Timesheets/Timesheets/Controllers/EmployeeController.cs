using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Abstractions;
using Timesheets.Models.Dto;

namespace Timesheets.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeManager _employeeManager;

    public EmployeeController(IEmployeeManager employeeManager)
    {
        _employeeManager = employeeManager;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var result = await _employeeManager.GetItem(id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _employeeManager.GetActiveEmployees();
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _employeeManager.GetItems();
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] EmployeeDto employeeDto)
    {
        var id = await _employeeManager.Create(employeeDto);
        return Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] EmployeeDto employeeDto)
    {
        var result = await _employeeManager.Update(id, employeeDto);
        if (result is null)
            return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var result = await _employeeManager.Delete(id);
        if (result is null)
            return NotFound();
        if (!result.Value)
            return BadRequest($"Can not delete employee with id: {id}");
        return Ok();
    }
}
