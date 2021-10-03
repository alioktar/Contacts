using Contacts.Core.Response.Abstract;
using Contacts.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.BusinessLogic.Services.Abstract
{
    public interface IPersonService
    {
        Task<IDataResponse<IList<PersonDto>>> GetAllAsync();
        Task<IDataResponse<PersonDto>> GetByIdAsync(Guid id);
        Task<IResponse> AddAsync(PersonAddDto entity);
        Task<IResponse> DeleteAsync(Guid id);
        Task<IResponse> UpdateAsync(PersonUpdateDto entity);
    }
}
