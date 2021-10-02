using Contacts.Core.Entities.Concrete;
using System;

namespace Contacts.Entities.Concrete
{
    public class Contact:Entity
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }

        public Guid PersonId { get; set; }
        public virtual Person Person { get; set; }

        public Guid AddressId { get; set; }
        public virtual Address Address { get; set; }
    }
}
