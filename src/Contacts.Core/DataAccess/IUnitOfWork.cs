using System;
using System.Threading.Tasks;

namespace Contacts.Core.DataAccess
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        Task<int> SaveChangesAsync();
    }
}
