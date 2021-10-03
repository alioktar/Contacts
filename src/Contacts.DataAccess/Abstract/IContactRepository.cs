using Contacts.Core.DataAccess;
using Contacts.Entities;
using System.Collections.Generic;

namespace Contacts.DataAccess.Abstract
{
    public interface IContactRepository : IEntityRepository<Contact>
    {
        IList<Contact> UpdateRange(IList<Contact> contacts);
    }
}
