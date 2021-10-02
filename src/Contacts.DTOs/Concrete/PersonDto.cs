using System.Collections.Generic;

namespace Contacts.DTOs.Concrete
{
    public class PersonDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }

        public IList<ContactDto> Contacts { get; set; } = new List<ContactDto>();
    }
}
