using Contacts.Core.DataAccess.EntityFreamework;
using Contacts.DataAccess.Abstract;
using Contacts.DTOs;
using Contacts.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.DataAccess.Concrete.EntityFreamework.Repositories
{
    public class ContactRepository : EntityRepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository(DbContext context) : base(context) { }

        public IList<Contact> UpdateRange(IList<Contact> contacts)
        {
            if (contacts == null)
                throw new ArgumentNullException(nameof(contacts));

            Entities.UpdateRange(contacts);
            return contacts;
        }

        public async Task<IList<LocationReportDto>> GetLocationReport()
        {
            return await Entities.Join(Entities, c => c.PersonId, c2 => c2.PersonId,
                                                 (c, c2) => new
                                                 {
                                                     PersonId = c.PersonId,
                                                     ContactTypeOne = c.ContactType,
                                                     Location = c.Description,
                                                     PhoneNumber = c2.Description,
                                                     ContactTypeTwo = c2.ContactType,
                                                 })
                                          .Where(x => x.ContactTypeTwo == Constants.ContactType.PhoneNumber && x.ContactTypeOne == Constants.ContactType.Location)
                                          .GroupBy(x => x.Location, (current, groups) => new LocationReportDto
                                          {
                                              Location = current,
                                              PersonCount = groups.Select(g => g.PersonId).Distinct().Count(),
                                              PhoneNumberCount = groups.Select(g => g.Location).Count()
                                          })
                                          .OrderByDescending(lr => lr.PersonCount)
                                          .ToListAsync();
        }
    }
}
