using Lazurdit.Application.Common.Interfaces;

namespace Lazurdit.Infrastructure.Services;

public class DataBaseService<T> : IDataBaseService<T>
{
    private readonly Dictionary<int, T> _database = new ();

    private int _nextId = 1;
    public T Add(T item)
    {
        var id = _nextId++;
        SetProperty(item, "Id", id);
        _database.Add(id, item);
        return item;
    }
    public IEnumerable<T> Sort(Func<T, object> orderBy, string sortOrder)
    {
        if (sortOrder.ToLower() =="asc")
        {
            return _database.Values.OrderBy(orderBy);
        }
        return  _database.Values.OrderByDescending(orderBy);
    }
    public T GetById(int id)
    {
        return _database.ContainsKey(id) ? _database[id] : default;
    }

    public IEnumerable<T> GetAll()
    {
        return _database.Values;
    }

    public bool Update(int id, T item)
    {
        if (!_database.ContainsKey(id))
        {
            return false;
        }
        _database[id] = item;
        return true;
    }

    public bool Delete(int id)
    {
        if (!_database.ContainsKey(id))
        {
            return false;
        }
        _database.Remove(id);
        return true;
    }
    private void SetProperty(object obj, string propertyName, object value)
    {
        var property = obj.GetType().GetProperty(propertyName);
        property?.SetValue(obj, value);
    }
}