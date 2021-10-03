using Contacts.Core.DTOs;
using System;
using System.Collections.Generic;

namespace Contacts.DTOs
{
    public class PersonUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }

        public IList<ContactUpdateWithPersonDto> Contacts { get; set; } = new List<ContactUpdateWithPersonDto>();
    }
}
