using AutoMapper;
using Contacts.BusinessLogic.Core;
using Contacts.BusinessLogic.Core.Exceptions;
using Contacts.BusinessLogic.Services.Abstract;
using Contacts.Core.CrossCuttingConcerns.Caching;
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

        public PersonService(IUnitOfWork unitOfWork, IMapper mapper, ICacheManager cacheManager) : base(unitOfWork, mapper, cacheManager) { }

        public async Task<IResponse> AddAsync(PersonAddDto entity)
        {
            CacheManager.RemoveByPattern("Person:");
            var exists = await UnitOfWork.PersonRepository.GetAsync(p => p.Name.Trim().ToLower().Equals(entity.Name.Trim().ToLower()) &&
                                                                p.Surname.Trim().ToLower().Equals(entity.Surname.Trim().ToLower()));
            if (exists != null)
                throw new AlreadyExistsException($"Person already exists.");

            await UnitOfWork.PersonRepository.AddAsync(Mapper.Map<Person>(entity));
            await UnitOfWork.SaveChangesAsync();
            return new SuccessResponse("Person Successfully addded.");
        }

        public async Task<IResponse> UpdateAsync(PersonUpdateDto entity)
        {
            CacheManager.RemoveByPattern("Person:");
            _ = await CheckPerson(entity.Id);

            UnitOfWork.PersonRepository.Update(Mapper.Map<Person>(entity));
            await UnitOfWork.SaveChangesAsync();
            return new SuccessResponse("Person Successfully updated.");
        }

        public async Task<IResponse> DeleteAsync(Guid id)
        {
            CacheManager.RemoveByPattern("Person:");
            var deleted = await CheckPerson(id);

            UnitOfWork.PersonRepository.Delete(deleted);
            await UnitOfWork.SaveChangesAsync();
            return new SuccessResponse("Person Successfully deleted.");
        }

        public async Task<IDataResponse<IList<PersonDto>>> GetAllAsync()
        {
            if (CacheManager.IsAdd("Person:GetAll"))
                return new SuccessDataResponse<List<PersonDto>>(CacheManager.Get<List<PersonDto>>("Person:GetAll"));

            var list = await UnitOfWork.PersonRepository.GetListAsync(null, new Expression<Func<Person, object>>[] { p => p.Contacts });
            var responseData = Mapper.Map<List<PersonDto>>(list);

            CacheManager.Add("Person:GetAll", responseData);
            return new SuccessDataResponse<List<PersonDto>>(responseData);
        }


        public async Task<IDataResponse<PersonDto>> GetByIdAsync(Guid id)
        {
            if (CacheManager.IsAdd($"Person:{id}"))
                return new SuccessDataResponse<PersonDto>(CacheManager.Get<PersonDto>($"Person:{id}"));

            var person = await UnitOfWork.PersonRepository.GetAsync(p => p.Id == id, new Expression<Func<Person, object>>[] { p => p.Contacts });
            var responseData = Mapper.Map<PersonDto>(person);

            CacheManager.Add($"Person:{id}", responseData);
            return new SuccessDataResponse<PersonDto>(responseData);
        }

        private async Task<Person> CheckPerson(Guid id)
        {
            return await UnitOfWork.PersonRepository.GetAsync(p => p.Id == id) ?? throw new NotFoundException($"Person with id {id} not found.");
        }
    }
}
