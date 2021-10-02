using Contacts.Core.DataAccess;
using Contacts.DataAccess.Abstract;
using Contacts.DataAccess.Concrete.EntityFreamework.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.DataAccess.Concrete.EntityFreamework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        private PersonRepository _personRepository;
        private ContactRepository _contactRepository;
        private AddressRepository _addressRepository;
        private CompanyRepository _companyRepository;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public IPersonRepository PersonRepository => _personRepository = _personRepository ?? new PersonRepository(_context);
        public IContactRepository ContactRepository => _contactRepository = _contactRepository ?? new ContactRepository(_context);
        public IAddressRepository AddressRepository => _addressRepository = _addressRepository ?? new AddressRepository(_context);
        public ICompanyRepository CompanyRepository => _companyRepository = _companyRepository ?? new CompanyRepository(_context);

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                await RollbackEntityChanges();
                throw;
            }
        }

        protected async Task RollbackEntityChanges()
        {
            if (_context is DbContext dbContext)
            {
                var entries = dbContext.ChangeTracker.Entries()
                    .Where(e =>
                            e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted).ToList();

                entries.ForEach(entry =>
                {
                    entry.State = EntityState.Unchanged;
                });

                await _context.SaveChangesAsync();
            }
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
