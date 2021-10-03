using AutoMapper;
using Contacts.BusinessLogic.Core;
using Contacts.BusinessLogic.Core.Exceptions;
using Contacts.BusinessLogic.Services.Abstract;
using Contacts.Core.Aspects.Autofac.Caching;
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

        public async Task<IResponse> AddAsync(ContactAddDto entity)
        {
            var exists = await UnitOfWork.ContactRepository.GetAsync(c => c.ContactType == entity.ContactType &&
                                                                 c.Description.Trim().ToLower().Equals(entity.Description.Trim().ToLower()));
            if (exists != null)
                throw new AlreadyExistsException($"Contact already exists.");

            await UnitOfWork.ContactRepository.AddAsync(Mapper.Map<Contact>(entity));
            await UnitOfWork.SaveChangesAsync();
            return new SuccessResponse("Contact Successfully addded.");
        }

        public async Task<IResponse> UpdateAsync(ContactUpdateDto entity)
        {
            _ = await CheckContact(entity.Id);

            UnitOfWork.ContactRepository.Update(Mapper.Map<Contact>(entity));
            await UnitOfWork.SaveChangesAsync();
            return new SuccessResponse("Contact Successfully updated.");
        }

        public async Task<IResponse> UpdateRangeAsync(IList<ContactUpdateDto> contacts)
        {
            (contacts as List<ContactUpdateDto>).ForEach(contact => CheckContact(contact.Id).Wait());

            UnitOfWork.ContactRepository.UpdateRange(Mapper.Map<List<Contact>>(contacts));
            await UnitOfWork.SaveChangesAsync();
            return new SuccessResponse("Contacts Successfully updated.");
        }

        public async Task<IResponse> DeleteAsync(Guid id)
        {
            var deleted = await CheckContact(id);

            UnitOfWork.ContactRepository.Delete(deleted);
            await UnitOfWork.SaveChangesAsync();
            return new SuccessResponse("Contacts Successfully deleted.");
        }

        public async Task<IDataResponse<IList<ContactDto>>> GetAllAsync()
        {
            var list = await UnitOfWork.ContactRepository.GetListAsync();
            return new SuccessDataResponse<List<ContactDto>>(Mapper.Map<List<ContactDto>>(list));
        }

        public async Task<IDataResponse<IList<ContactDto>>> GetByPersonIdAsync(Guid id)
        {
            var list = await UnitOfWork.ContactRepository.GetListAsync(c => c.PersonId == id);
            return new SuccessDataResponse<List<ContactDto>>(Mapper.Map<List<ContactDto>>(list));
        }

        public async Task<IDataResponse<ContactDto>> GetByIdAsync(Guid id)
        {
            var Contact = await UnitOfWork.ContactRepository.GetAsync(c => c.Id == id, new Expression<Func<Contact, object>>[] { c => c.Person });
            return new SuccessDataResponse<ContactDto>(Mapper.Map<ContactDto>(Contact));
        }

        private async Task<Contact> CheckContact(Guid id)
        {
            return await UnitOfWork.ContactRepository.GetAsync(c => c.Id == id) ?? throw new NotFoundException($"Contact with id {id} not found.");
        }
    }
}
