using AutoMapper;
using Contacts.BusinessLogic.Core;
using Contacts.BusinessLogic.Services.Abstract;
using Contacts.Core.Response.Abstract;
using Contacts.Core.Response.Concrete;
using Contacts.DataAccess.Abstract;
using Contacts.DTOs.Concrete;
using Contacts.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Contacts.BusinessLogic.Services.Concrete
{
    public class CompanyService : BaseService, ICompanyService
    {
        public CompanyService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public CompanyService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public async Task<IResponse> AddAsync(CompanyDto entity)
        {
            await UnitOfWork.CompanyRepository.AddAsync(Mapper.Map<Company>(entity));
            await UnitOfWork.SaveChangesAsync();
            return new SuccessResponse();
        }

        public async Task<IResponse> DeleteAsync(CompanyDto entity)
        {
            UnitOfWork.CompanyRepository.Delete(Mapper.Map<Company>(entity));
            await UnitOfWork.SaveChangesAsync();
            return new SuccessResponse();
        }

        public async Task<IDataResponse<List<CompanyDto>>> GetAllAsync()
        {
            var list = await UnitOfWork.CompanyRepository.GetListAsync();
            return new SuccessDataResponse<List<CompanyDto>>(Mapper.Map<List<CompanyDto>>(list));
        }

        public async Task<IDataResponse<CompanyDto>> GetByIdAsync(Guid id)
        {
            var Company = await UnitOfWork.CompanyRepository.GetAsync(p => p.Id == id, new Expression<Func<Company, object>>[] { c => c.Address });
            return new SuccessDataResponse<CompanyDto>(Mapper.Map<CompanyDto>(Company));
        }

        public async Task<IResponse> UpdateAsync(CompanyDto entity)
        {
            UnitOfWork.CompanyRepository.Delete(Mapper.Map<Company>(entity));
            await UnitOfWork.SaveChangesAsync();
            return new SuccessResponse();
        }
    }
}
