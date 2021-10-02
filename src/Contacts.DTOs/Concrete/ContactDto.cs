using Contacts.Core.DTOs;
using System;

namespace Contacts.DTOs.Concrete
{
    public class ContactDto : IDto
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }

        public PersonDto Person { get; set; }
        public AddressDto Address { get; set; }
    }
}
