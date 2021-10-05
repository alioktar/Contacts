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
    public class ContactService : BaseService, IContactService
    {
        public ContactService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public ContactService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public ContactService(IUnitOfWork unitOfWork, IMapper mapper, ICacheManager cacheManager) : base(unitOfWork, mapper, cacheManager) { }

        public async Task<IResponse> AddAsync(ContactAddDto entity)
        {
            CacheManager.RemoveByPattern("Contact:");
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
            CacheManager.RemoveByPattern("Contact:");
            _ = await CheckContact(entity.Id);

            UnitOfWork.ContactRepository.Update(Mapper.Map<Contact>(entity));
            await UnitOfWork.SaveChangesAsync();
            return new SuccessResponse("Contact Successfully updated.");
        }

        public async Task<IResponse> UpdateRangeAsync(IList<ContactUpdateDto> contacts)
        {
            CacheManager.RemoveByPattern("Contact:");
            (contacts as List<ContactUpdateDto>).ForEach(contact => CheckContact(contact.Id).Wait());

            UnitOfWork.ContactRepository.UpdateRange(Mapper.Map<List<Contact>>(contacts));
            await UnitOfWork.SaveChangesAsync();
            return new SuccessResponse("Contacts Successfully updated.");
        }

        public async Task<IResponse> DeleteAsync(Guid id)
        {
            CacheManager.RemoveByPattern("Contact:");
            var deleted = await CheckContact(id);

            UnitOfWork.ContactRepository.Delete(deleted);
            await UnitOfWork.SaveChangesAsync();
            return new SuccessResponse("Contacts Successfully deleted.");
        }

        public async Task<IDataResponse<IList<ContactDto>>> GetAllAsync()
        {
            if (CacheManager.IsAdd("Contact:GetAll"))
                return new SuccessDataResponse<IList<ContactDto>>(CacheManager.Get<IList<ContactDto>>("Contact:GetAll"));

            var list = await UnitOfWork.ContactRepository.GetListAsync();
            var responseData = Mapper.Map<List<ContactDto>>(list);

            CacheManager.Add("Contact:GetAll", responseData);
            return new SuccessDataResponse<List<ContactDto>>(responseData);
        }

        public async Task<IDataResponse<IList<ContactDto>>> GetContactsByPersonIdAsync(Guid id)
        {
            if (CacheManager.IsAdd($"Contact:GetByPersonId:{id}"))
                return new SuccessDataResponse<IList<ContactDto>>(CacheManager.Get<IList<ContactDto>>($"Contact:GetByPersonId:{id}"));

            var list = await UnitOfWork.ContactRepository.GetListAsync(c => c.PersonId == id);
            var responseData = Mapper.Map<List<ContactDto>>(list);

            CacheManager.Add($"Contact:GetByPersonId:{id}", responseData);
            return new SuccessDataResponse<List<ContactDto>>();
        }

        public async Task<IDataResponse<ContactDto>> GetByIdAsync(Guid id)
        {
            if (CacheManager.IsAdd($"Contact:{id}"))
                return new SuccessDataResponse<ContactDto>(CacheManager.Get<ContactDto>($"Contact:{id}"));

            var contact = await UnitOfWork.ContactRepository.GetAsync(c => c.Id == id, new Expression<Func<Contact, object>>[] { c => c.Person });
            var responseData = Mapper.Map<ContactDto>(contact);

            CacheManager.Add($"Contact:{id}", responseData);
            return new SuccessDataResponse<ContactDto>();
        }

        private async Task<Contact> CheckContact(Guid id)
        {
            return await UnitOfWork.ContactRepository.GetAsync(c => c.Id == id) ?? throw new NotFoundException($"Contact with id {id} not found.");
        }

        public async Task<IList<LocationReportDto>> GetLocationReport()
        {
            return await UnitOfWork.ContactRepository.GetLocationReport();
        }
    }
}
