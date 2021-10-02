using Contacts.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Contacts.DataAccess.Concrete.EntityFreamework.Contexts
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions<ContactsContext> options) : base(options) { }

        public DbSet<Person> People { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
