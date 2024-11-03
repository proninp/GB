namespace Timesheets.Domain.Abstractions;

public interface IManager<TGet, TPk, TGetDto, TCreateDto>
{
    Task<TGet?> GetItem(TPk id);

    Task<IEnumerable<TGet>?> GetItems();

    Task<TPk> Create(TCreateDto item);

    Task<bool?> Update(TPk id, TGetDto itemDto);

    Task<bool?> Delete(TPk id);
}
