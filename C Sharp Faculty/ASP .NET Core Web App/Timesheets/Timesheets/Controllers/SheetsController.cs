﻿using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Interfaces;
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
    public async Task<IActionResult> Get(Guid id)
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
    public async Task<IActionResult> Create([FromBody] SheetCreateRequest sheetDto)
    {
        var isAllowedToCreate = await _contractManager.CheckContractIsActive(sheetDto.ContractId);
        if (!isAllowedToCreate)
            return BadRequest($"Contract '{sheetDto.ContractId}' is not active.");
        
        var id = await _sheetManager.Create(sheetDto);
        return Ok(id);
    }
}
