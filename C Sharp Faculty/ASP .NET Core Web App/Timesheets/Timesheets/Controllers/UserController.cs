using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Abstractions;
using Timesheets.Models.Dto;

namespace Timesheets.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserManager _userManager;

    public UserController(IUserManager userManager)
    {
        _userManager = userManager;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var result = await _userManager.GetItem(id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _userManager.GetItems();
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserDto userDto)
    {
        var id = await _userManager.Create(userDto);
        return Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UserDto userDto)
    {
        var result = await _userManager.Update(id, userDto);
        if (result is null)
            return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var result = await _userManager.Delete(id);
        if (result is null)
            return NotFound();
        if (!result.Value)
            return BadRequest($"Can not delete user with id: {id}");
        return Ok();
    }
}
