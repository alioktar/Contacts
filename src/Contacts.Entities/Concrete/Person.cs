using Contacts.Core.Entities.Concrete;
using System.Collections.Generic;

namespace Contacts.Entities.Concrete
{
    public class Person : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }

        public virtual IList<Contact> Contacts { get; set; }
    }
}
