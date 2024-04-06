using System.Collections;
using Lazurdit.Domain.Entities;

namespace Lazurdit.Application.Common.Interfaces;

public interface IContactRepository
{
    Contact GetById(int id);
    IEnumerable<Contact> GetAll();
    Contact Add(Contact contact);
    bool Update(Contact contact);
    bool Delete(int id);
    IEnumerable<Contact> Sort(Func<Contact,object> selector,string orderBy);
}