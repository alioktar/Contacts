using Contacts.Core.DTOs;

namespace Contacts.DTOs
{
    public class LocationReportDto : IDto
    {
        public string Location { get; set; }
        public int PersonCount { get; set; }
        public int PhoneNumberCount { get; set; }
    }
}
