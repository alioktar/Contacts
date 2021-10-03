using Contacts.Constants;
using Contacts.Core.DTOs;

namespace Contacts.DTOs
{
    public class ContactAddWithPersonDto : IDto
    {
        public string Description { get; set; }
        public ContactType ContactType { get; set; }
    }
}
