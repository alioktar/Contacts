using Contacts.Core.DTOs;
using System.Collections.Generic;

namespace Contacts.DTOs
{
    public class PersonAddDto : IDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }

        public IList<ContactAddWithPersonDto> Contacts { get; set; } = new List<ContactAddWithPersonDto>();
    }
}
