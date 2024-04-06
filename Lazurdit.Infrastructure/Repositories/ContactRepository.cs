using Lazurdit.Application.Common.Interfaces;
using Lazurdit.Domain.Entities;

namespace Lazurdit.Infrastructure.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly IDataBaseService<Contact> _dataBase;

    public ContactRepository(IDataBaseService<Contact> dataBase)
    {
        _dataBase = dataBase;
    }
    public Contact GetById(int id)
    {
        
        return _dataBase.GetById(id);
    }
    public IEnumerable<Contact> GetAll()
    {
        return _dataBase.GetAll();
    }

    public Contact Add(Contact contact)
    {
        return _dataBase.Add(contact);
    }

    public bool Update(Contact contact)
    {
        return _dataBase.Update(contact.Id,contact);
    }
    public bool Delete(int id)
    {
        return _dataBase.Delete(id);
    }

    public IEnumerable<Contact> Sort(Func<Contact,object> selector,string orderBy)
    {
        return _dataBase.Sort(selector, orderBy);
    }
}