using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Abstractions;
using Timesheets.Domain.InterAbstractionsfaces;
using Timesheets.Models.Dto;

namespace Timesheets.Controllers;

[ApiController]
[Route("[controller]")]
public class SheetsController : ControllerBase
{
    private readonly ISheetManager _sheetManager;
    private readonly IContractManager _contractManager;

    public SheetsController(ISheetManager sheetManager, IContractManager contractManager)
    {
        _sheetManager = sheetManager;
        _contractManager = contractManager;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var result = await _sheetManager.GetItem(id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _sheetManager.GetItems();
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SheetDto sheetDto)
    {
        var isAllowedToCreate = await _contractManager.CheckContractIsActive(sheetDto.ContractId);
        if (!isAllowedToCreate.HasValue)
            return NotFound($"Contract with id: {sheetDto.ContractId} was not found");
        if (!isAllowedToCreate.Value)
            return BadRequest($"Contract '{sheetDto.ContractId}' is not active.");

        var id = await _sheetManager.Create(sheetDto);
        return Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] SheetDto sheetDto)
    {
        var isAllowedToUpdate = await _contractManager.CheckContractIsActive(sheetDto.ContractId);
        if (!isAllowedToUpdate.HasValue)
            return NotFound($"Contract with id: {sheetDto.ContractId} was not found");
        if (!isAllowedToUpdate.Value)
            return BadRequest($"Contract '{sheetDto.ContractId}' is not active.");

        await _sheetManager.Update(id, sheetDto);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var result = await _sheetManager.Delete(id);
        if (!result)
            return NotFound();
        return Ok();
    }
}
