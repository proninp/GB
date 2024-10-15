﻿namespace Timesheets.Data.Interfaces;

public interface IRepository<T>
{
    Task<T?> GetItem(Guid id);

    Task<IEnumerable<T>?> GetItems();

    Task Add(T item);

    Task Update(T item);
}
