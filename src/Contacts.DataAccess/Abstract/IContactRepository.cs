using Contacts.Core.DataAccess;
using Contacts.Entities.Concrete;

namespace Contacts.DataAccess.Abstract
{
    public interface IContactRepository : IEntityRepository<Contact>
    {
    }
}
