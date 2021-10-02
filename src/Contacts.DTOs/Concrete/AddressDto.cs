using Contacts.Core.DTOs;
using System;

namespace Contacts.DTOs.Concrete
{
    public class AddressDto :IDto
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public string Street { get; set; }
        public string Description { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
    }
}
