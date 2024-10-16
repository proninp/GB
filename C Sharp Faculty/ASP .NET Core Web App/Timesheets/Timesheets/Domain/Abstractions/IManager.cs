namespace Timesheets.Domain.Abstractions;

public interface IManager<T, TPk, TDto>
{
    Task<T?> GetItem(TPk id);

    Task<IEnumerable<T>> GetItems();

    Task<TPk> Create(TDto sheet);

    Task<bool> Update(TPk id, TDto sheetDto);

    Task<bool> Delete(TPk id);
}
