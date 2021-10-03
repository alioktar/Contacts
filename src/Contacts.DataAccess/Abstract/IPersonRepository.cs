using Contacts.Core.DataAccess;
using Contacts.Entities;

namespace Contacts.DataAccess.Abstract
{
    public interface IPersonRepository:IEntityRepository<Person>
    {
    }
}
