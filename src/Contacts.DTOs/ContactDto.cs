using Contacts.Constants;
using Contacts.Core.DTOs;
using System;

namespace Contacts.DTOs
{
    public class ContactDto : IDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public ContactType ContactType { get; set; }

        public PersonDto Person { get; set; }
    }
}
