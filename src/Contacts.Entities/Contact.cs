using Contacts.Constants;
using Contacts.Core.Entities.Concrete;
using System;

namespace Contacts.Entities
{
    public class Contact:Entity
    {
        public string Description { get; set; }
        public ContactType ContactType { get; set; }

        public Guid PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
