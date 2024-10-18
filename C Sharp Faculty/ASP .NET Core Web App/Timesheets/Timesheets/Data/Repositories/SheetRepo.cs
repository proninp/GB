using Microsoft.EntityFrameworkCore;
using Timesheets.Data.Abstractions;
using Timesheets.Models;

namespace Timesheets.Data.Repositories;

public class SheetRepo : ISheetRepo
{
    private readonly TimesheetsDBContext _context;

    public SheetRepo(TimesheetsDBContext context)
    {
        _context = context;
    }

    public async Task<Sheet?> GetItem(Guid id)
    {
        return await _context
            .Sheets
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<IEnumerable<Sheet>?> GetItems()
    {
        return await _context
            .Sheets
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task Add(Sheet item)
    {
        _context.Add(item);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> Update(Sheet item)
    {
        _context.Sheets.Update(item);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> Delete(Guid id)
    {
        var result = await _context.Sheets.Where(s => s.Id == id).ExecuteDeleteAsync();
        return result > 0;
    }
}
