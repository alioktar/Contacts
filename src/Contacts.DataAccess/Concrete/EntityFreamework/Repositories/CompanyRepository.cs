using Contacts.Core.DataAccess.EntityFreamework;
using Contacts.DataAccess.Abstract;
using Contacts.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Contacts.DataAccess.Concrete.EntityFreamework.Repositories
{
    public class CompanyRepository : EntityRepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(DbContext context) : base(context)
        {

        }
    }
}
