using Contacts.Core.DataAccess.EntityFreamework;
using Contacts.DataAccess.Abstract;
using Contacts.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contacts.DataAccess.Concrete.EntityFreamework.Repositories
{
    public class ContactRepository : EntityRepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository(DbContext context) : base(context)
        {

        }
    }
}
