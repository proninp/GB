using Microsoft.EntityFrameworkCore;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation;

public class SheetRepo : ISheetRepo
{
    private readonly TimesheetsDBContext _context;

    public SheetRepo(TimesheetsDBContext context)
    {
        _context = context;
    }

    public async Task Add(Sheet item)
    {
        _context.Add(item);
        await _context.SaveChangesAsync();
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

    public async Task Update(Sheet item)
    {
        _context.Sheets.Update(item);
        await _context.SaveChangesAsync();
    }
}
