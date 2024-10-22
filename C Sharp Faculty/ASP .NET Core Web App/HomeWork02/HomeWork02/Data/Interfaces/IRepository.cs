namespace HomeWork02.Data.Interfaces;

public interface IRepository<T>
{
    Task<T?> GetItem(Guid id);

    Task<IEnumerable<T>?> GetItems(int skip, int take);

    Task Add(T item);

    Task<bool?> Update(T item);

    Task<bool> Delete(Guid id);
}
