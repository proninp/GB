using HomeWork02.DataTransferObjects;
using HomeWork02.Domain.Models;
using HomeWork02.Domain.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork02.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonsController : ControllerBase
{
    private IPersonManager _personManager;

    public PersonsController(IPersonManager personManager)
    {
        _personManager = personManager;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Person>> GetPersonById(Guid id)
    {
        var result = await _personManager.GetPerson(id);
        if (result is null)
            return NotFound();
        return Ok(result);
    }

    [HttpGet("search")]
    public async Task<ActionResult<List<Person>>> GetPersonBySearchTerm(string term)
    {
        var result = await _personManager.GetPerson(term);
        if (result is null)
            return NotFound();
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Person>>> GetPersons([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        if (take <= 0 || skip < 0)
            return BadRequest("Take parameter must be greater than 0.");
        var persons = await _personManager.GetPersons(skip, take);
        if (persons is null)
            return NotFound();
        return Ok(persons);
    }

    [HttpPost]
    public async Task<ActionResult<int>> AddPerson([FromBody] PersonDto person)
    {
        return Ok(await _personManager.Create(person));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePerson([FromRoute] Guid id, [FromBody] PersonDto personDto)
    {
        var result = await _personManager.Update(id, personDto);
        if (result is null)
            return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePerson([FromRoute] Guid id)
    {
        var result = await _personManager.Delete(id);
        if (result is null)
            return NotFound();
        return NoContent();
    }
}