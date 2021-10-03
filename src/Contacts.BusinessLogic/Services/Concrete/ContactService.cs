using AutoMapper;
using Contacts.BusinessLogic.Core;
using Contacts.BusinessLogic.Services.Abstract;
using Contacts.Core.Response.Abstract;
using Contacts.Core.Response.Concrete;
using Contacts.DataAccess.Abstract;
using Contacts.DTOs;
using Contacts.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Contacts.BusinessLogic.Services.Concrete
{
    public class ContactService : BaseService, IContactService
    {
        public ContactService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public ContactService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public async Task<IResponse> AddAsync(ContactDto entity)
        {
            await UnitOfWork.ContactRepository.AddAsync(Mapper.Map<Contact>(entity));
            await UnitOfWork.SaveChangesAsync();
            return new SuccessResponse();
        }

        public async Task<IResponse> DeleteAsync(ContactDto entity)
        {
            UnitOfWork.ContactRepository.Delete(Mapper.Map<Contact>(entity));
            await UnitOfWork.SaveChangesAsync();
            return new SuccessResponse();
        }

        public async Task<IDataResponse<List<ContactDto>>> GetAllAsync()
        {
            var list = await UnitOfWork.ContactRepository.GetListAsync();
            return new SuccessDataResponse<List<ContactDto>>(Mapper.Map<List<ContactDto>>(list));
        }

        public async Task<IDataResponse<ContactDto>> GetByIdAsync(Guid id)
        {
            var Contact = await UnitOfWork.ContactRepository.GetAsync(p => p.Id == id, new Expression<Func<Contact, object>>[] { c => c.Person });
            return new SuccessDataResponse<ContactDto>(Mapper.Map<ContactDto>(Contact));
        }

        public async Task<IResponse> UpdateAsync(ContactDto entity)
        {
            UnitOfWork.ContactRepository.Delete(Mapper.Map<Contact>(entity));
            await UnitOfWork.SaveChangesAsync();
            return new SuccessResponse();
        }
    }
}
