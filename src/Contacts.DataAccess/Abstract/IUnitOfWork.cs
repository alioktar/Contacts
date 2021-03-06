using System;
using System.Threading.Tasks;

namespace Contacts.DataAccess.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        public IPersonRepository PersonRepository { get; }
        public IContactRepository ContactRepository { get; }

        Task<int> SaveChangesAsync();
    }
}
