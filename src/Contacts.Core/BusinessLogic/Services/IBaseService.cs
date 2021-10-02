using Contacts.Core.Entities.Abstract;
using Contacts.Core.Response.Abstract;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Contacts.Core.BusinessLogic.Services
{
    public interface IBaseService
    {
        Task<IDataResponse<List<IEntity>>> GetAllAsync();
        Task<IDataResponse<IEntity>> GetByIdAsync();
        Task<IResponse> AddAsync(IEntity entity);
        Task<IResponse> DeleteAsync(IEntity entity);
        Task<IResponse> UpdateAsync(IEntity entity);
    }
}
