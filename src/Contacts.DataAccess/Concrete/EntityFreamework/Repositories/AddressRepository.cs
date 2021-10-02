using Contacts.Core.DataAccess.EntityFreamework;
using Contacts.DataAccess.Abstract;
using Contacts.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Contacts.DataAccess.Concrete.EntityFreamework.Repositories
{
    public class AddressRepository : EntityRepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(DbContext context) : base(context)
        {

        }
    }
}
