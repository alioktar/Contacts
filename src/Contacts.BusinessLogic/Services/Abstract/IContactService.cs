using Contacts.Core.Response.Abstract;
using Contacts.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.BusinessLogic.Services.Abstract
{
    public interface IContactService
    {
        Task<IDataResponse<IList<ContactDto>>> GetAllAsync();
        Task<IDataResponse<IList<ContactDto>>> GetContactsByPersonIdAsync(Guid id);
        Task<IDataResponse<ContactDto>> GetByIdAsync(Guid id);
        Task<IResponse> AddAsync(ContactAddDto entity);
        Task<IResponse> DeleteAsync(Guid id);
        Task<IResponse> UpdateAsync(ContactUpdateDto entity);
        Task<IResponse> UpdateRangeAsync(IList<ContactUpdateDto> contacts);
        Task<IList<LocationReportDto>> GetLocationReport();
    }
}
