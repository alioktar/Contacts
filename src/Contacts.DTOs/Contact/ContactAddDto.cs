using Contacts.Constants;
using System;

namespace Contacts.DTOs
{
    public class ContactAddDto
    {
        public Guid PersonId { get; set; }
        public string Description { get; set; }
        public ContactType ContactType { get; set; }
    }
}
