using Contacts.Core.DataAccess.EntityFreamework;
using Contacts.DataAccess.Abstract;
using Contacts.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Contacts.DataAccess.Concrete.EntityFreamework.Repositories
{
    public class ContactRepository : EntityRepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository(DbContext context) : base(context) { }

        public IList<Contact> UpdateRange(IList<Contact> contacts)
        {
            if (contacts == null)
                throw new ArgumentNullException(nameof(contacts));

            Entities.UpdateRange(contacts);
            return contacts;
        }
    }
}
