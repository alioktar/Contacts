using Contacts.Core.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Contacts.Entities.Concrete
{
    public class Company:Entity
    {
        public string Name { get; set; }

        public Guid AddressId { get; set; }
        public virtual Address Address { get; set; }

        public virtual IList<Person> People { get; set; } = new List<Person>();
    }
}
