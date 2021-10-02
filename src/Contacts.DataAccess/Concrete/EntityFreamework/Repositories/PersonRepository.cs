using Contacts.Core.DataAccess.EntityFreamework;
using Contacts.DataAccess.Abstract;
using Contacts.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Contacts.DataAccess.Concrete.EntityFreamework.Repositories
{
    public class PersonRepository : EntityRepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(DbContext context) : base(context)
        {

        }
    }
}
