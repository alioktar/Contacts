using Contacts.Core.DTOs;
using System;
using System.Collections.Generic;

namespace Contacts.DTOs.Concrete
{
    public class CompanyDto : IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public AddressDto Address { get; set; }
        public IList<PersonDto> People { get; set; } = new List<PersonDto>();
    }
}
