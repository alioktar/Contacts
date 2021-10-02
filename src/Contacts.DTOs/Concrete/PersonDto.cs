using Contacts.Core.DTOs;
using System;
using System.Collections.Generic;

namespace Contacts.DTOs.Concrete
{
    public class PersonDto : IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public CompanyDto Company { get; set; }

        public IList<ContactDto> Contacts { get; set; } = new List<ContactDto>();
    }
}
