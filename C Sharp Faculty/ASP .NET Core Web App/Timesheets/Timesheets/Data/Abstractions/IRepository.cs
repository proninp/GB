namespace Timesheets.Data.Abstractions;

public interface IRepository<T>
{
    Task<T?> GetItem(Guid id);

    Task<IEnumerable<T>?> GetItems();

    Task Add(T item);

    Task<bool> Update(T item);

    Task<bool> Delete(Guid id);
}
