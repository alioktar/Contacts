using Contacts.Core.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Contacts.Entities.Concrete
{
    public class Person : Entity
    {
        public Person()
        {
            Contacts = new List<Contact>();
        }

        public string Name { get; set; }
        public string Surname { get; set; }

        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public virtual IList<Contact> Contacts { get; set; }
    }
}
