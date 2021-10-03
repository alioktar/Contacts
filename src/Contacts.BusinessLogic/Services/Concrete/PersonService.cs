using AutoMapper;
using Contacts.BusinessLogic.Core;
using Contacts.BusinessLogic.Core.Exceptions;
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

        public async Task<IResponse> AddAsync(PersonAddDto entity)
        {
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
            _ = await CheckPerson(entity.Id);

            UnitOfWork.PersonRepository.Update(Mapper.Map<Person>(entity));
            await UnitOfWork.SaveChangesAsync();
            return new SuccessResponse("Person Successfully updated.");
        }

        public async Task<IResponse> DeleteAsync(Guid id)
        {
            var deleted = await CheckPerson(id);

            UnitOfWork.PersonRepository.Delete(deleted);
            await UnitOfWork.SaveChangesAsync();
            return new SuccessResponse("Person Successfully deleted.");
        }

        public async Task<IDataResponse<IList<PersonDto>>> GetAllAsync()
        {
            var list = await UnitOfWork.PersonRepository.GetListAsync(null, new Expression<Func<Person, object>>[] { p => p.Contacts });
            return new SuccessDataResponse<List<PersonDto>>(Mapper.Map<List<PersonDto>>(list));
        }

        public async Task<IDataResponse<PersonDto>> GetByIdAsync(Guid id)
        {
            var person = await UnitOfWork.PersonRepository.GetAsync(p => p.Id == id, new Expression<Func<Person, object>>[] { p => p.Contacts });
            return new SuccessDataResponse<PersonDto>(Mapper.Map<PersonDto>(person));
        }

        private async Task<Person> CheckPerson(Guid id)
        {
            return await UnitOfWork.PersonRepository.GetAsync(p => p.Id == id) ?? throw new NotFoundException($"Person with id {id} not found.");
        }
    }
}
