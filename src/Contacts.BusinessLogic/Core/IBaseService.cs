using Contacts.Core.DTOs;
using Contacts.Core.Response.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.BusinessLogic.Core
{
    public interface IBaseService<TDto> where TDto : class, IDto, new()
    {
        Task<IDataResponse<List<TDto>>> GetAllAsync();
        Task<IDataResponse<TDto>> GetByIdAsync(Guid id);
        Task<IResponse> AddAsync(TDto entity);
        Task<IResponse> DeleteAsync(TDto entity);
        Task<IResponse> UpdateAsync(TDto entity);
    }
}
