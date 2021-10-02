using AutoMapper;
using Contacts.BusinessLogic.Services.Abstract;
using Contacts.Core.BusinessLogic.Services;
using Contacts.Core.DataAccess;
using Contacts.Core.Entities.Abstract;
using Contacts.Core.Response.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.BusinessLogic.Services.Concrete
{
    public class CompanyService : BaseService, ICompanyService
    {
        public CompanyService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public CompanyService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public Task<IResponse> AddAsync(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> DeleteAsync(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResponse<List<IEntity>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResponse<IEntity>> GetByIdAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> UpdateAsync(IEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
