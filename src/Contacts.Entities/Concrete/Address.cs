using Contacts.Core.Entities.Concrete;

namespace Contacts.Entities.Concrete
{
    public class Address : Entity
    {
        public string City { get; set; }
        public string Town { get; set; }
        public string Street { get; set; }
        public string Description { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
    }
}
