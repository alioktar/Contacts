using Contacts.Core.DataAccess;
using Contacts.DTOs;
using Contacts.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.DataAccess.Abstract
{
    public interface IContactRepository : IEntityRepository<Contact>
    {
        IList<Contact> UpdateRange(IList<Contact> contacts);
        Task<IList<LocationReportDto>> GetLocationReport();
    }
}
