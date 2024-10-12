namespace HomeWork02.Data.Interfaces;

public interface IRepository<T>
{
    T? GetItem(int id);

    IEnumerable<T>? GetItems(int skip, int take);

    void Add(T item);

    void Delete(T item);
}
