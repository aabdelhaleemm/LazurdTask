namespace Lazurdit.Application.Common.Interfaces;

public interface IDataBaseService<T>
{
    T Add(T item);
    T GetById(int id);
    IEnumerable<T> GetAll();
    bool Update(int id, T item);
    bool Delete(int id);
    public IEnumerable<T> Sort(Func<T, object> orderBy, string sortOrder);
}