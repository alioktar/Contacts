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
    public class PersonService : BaseService, IPersonService
    {
        public PersonService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public PersonService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public async Task<IResponse> AddAsync(PersonDto entity)
        {
            await UnitOfWork.PersonRepository.AddAsync(Mapper.Map<Person>(entity));
            await UnitOfWork.SaveChangesAsync();
            return new SuccessResponse();
        }

        public async Task<IResponse> DeleteAsync(PersonDto entity)
        {
            UnitOfWork.PersonRepository.Delete(Mapper.Map<Person>(entity));
            await UnitOfWork.SaveChangesAsync();
            return new SuccessResponse();
        }

        public async Task<IDataResponse<List<PersonDto>>> GetAllAsync()
        {
            var list = await UnitOfWork.PersonRepository.GetListAsync(null, new Expression<Func<Person, object>>[] { p => p.Company, p => p.Contacts });
            return new SuccessDataResponse<List<PersonDto>>(Mapper.Map<List<PersonDto>>(list));
        }

        public async Task<IDataResponse<PersonDto>> GetByIdAsync(Guid id)
        {
            var person = await UnitOfWork.PersonRepository.GetAsync(p => p.Id == id, new Expression<Func<Person, object>>[] { p => p.Company, p => p.Contacts });
            return new SuccessDataResponse<PersonDto>(Mapper.Map<PersonDto>(person));
        }

        public async Task<IResponse> UpdateAsync(PersonDto entity)
        {
            UnitOfWork.PersonRepository.Delete(Mapper.Map<Person>(entity));
            await UnitOfWork.SaveChangesAsync();
            return new SuccessResponse();
        }
    }
}
