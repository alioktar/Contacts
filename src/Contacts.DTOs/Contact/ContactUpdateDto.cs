using Contacts.Constants;
using Contacts.Core.DTOs;
using System;

namespace Contacts.DTOs
{
    public class ContactUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public string Description { get; set; }
        public ContactType ContactType { get; set; }
    }
}
